﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace IntegracionKHIPU.Utils
{
    public class ProxyRestServices
    {
        public HttpResponseMessage CallService(string urlAPI, Constant.Verbs Action, object Param, Dictionary<string, string> Header)
        {
            using (var client = new HttpClient())
            {
                if (Header != null)
                {
                    foreach (var item in Header)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                var response = new HttpResponseMessage();

                if (Constant.Verbs.GET.Equals(Action))
                {
                    response = client.GetAsync(new Uri(urlAPI)).Result;
                }
                else if (Constant.Verbs.POST.Equals(Action))
                {
                    if (Param != null && Param.GetType().Equals(typeof(FormUrlEncodedContent)))
                    {
                        var content = (FormUrlEncodedContent)Param;
                        response = client.PostAsync(new Uri(urlAPI), content).Result;
                    }
                    else
                    {
                        var json = JsonConvert.SerializeObject(Param);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        response = client.PostAsync(new Uri(urlAPI), content).Result;
                    }
                }
                else if (Constant.Verbs.PUT.Equals(Action))
                {
                    var json = JsonConvert.SerializeObject(Param);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = client.PutAsync(new Uri(urlAPI), content).Result;
                }
                else if (Constant.Verbs.PATCH.Equals(Action))
                {
                    var json = JsonConvert.SerializeObject(Param);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(new HttpMethod("PATCH"), new Uri(urlAPI))
                    {
                        Content = content
                    };

                    response = client.SendAsync(request).Result;
                }

                return response;
            }
        }
    }
}