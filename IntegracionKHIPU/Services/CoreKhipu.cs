using IntegracionKHIPU.Classes;
using IntegracionKHIPU.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace IntegracionKHIPU.Services
{
    public class CoreKhipu: ProxyRestServices
    {
        private readonly Dictionary<string, string> parameters;

        public CoreKhipu()
        {
            parameters = ConstantKhipu.Parameters();
        }

        public static CoreKhipu GetInstance
        {
            get
            {
                return new CoreKhipu();
            }
        }
        public Khipu Get_Banks()
        {
            Dictionary<string, string> Headers = new Dictionary<string, string>();
            Headers.Add("x-api-key", parameters["API_KHIPU"]);
            var param = new string[] { };

            using (HttpResponseMessage resp = base.CallService(parameters["URL_KHIPU"] + parameters["GET_BANKS"], Constant.Verbs.GET, param, Headers))
            {
                string responseContent = resp.Content.ReadAsStringAsync().Result;
                if (!resp.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la llamada al servicio: {(int)resp.StatusCode} {resp.ReasonPhrase}. Contenido: {responseContent}");
                }

                try
                {
                    return JsonConvert.DeserializeObject<Khipu>(responseContent);
                }
                catch (JsonException jsonEx)
                {
                    throw new Exception("Error deserializando el contenido de la respuesta: " + jsonEx.Message + ". Contenido: " + responseContent, jsonEx);
                }
            }
        }
    }
}