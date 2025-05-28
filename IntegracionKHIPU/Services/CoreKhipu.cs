using IntegracionKHIPU.Classes;
using IntegracionKHIPU.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        public Khipu Create_Payment(Khipu oKhipu)
        {
            Dictionary<string, string> Headers = new Dictionary<string, string>();
            Headers.Add("x-api-key", parameters["API_KHIPU"]);
            Headers.Add("Accept", "*/*");
            var param = new
            {
                amount = oKhipu.amount,
                currency =  "CLP",
                subject = oKhipu.subject,
                return_url = ConfigurationManager.AppSettings.Get("RETURN_URL"),
                cancel_url = ConfigurationManager.AppSettings.Get("CANCEL_URL"),
                picture_url = ConfigurationManager.AppSettings.Get("PICTURE_URL"),
                send_email = true,
                payer_name = oKhipu.payer_name,
                payer_email = oKhipu.payer_email,
                bank_id = oKhipu.bank_id
            };
            using (HttpResponseMessage resp = base.CallService(parameters["URL_KHIPU"] + parameters["CREATE_PAYMENT"], Constant.Verbs.POST, param, Headers))
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

        public Khipu Get_Payment_By_ID(Khipu oKhipu)
        {
            Dictionary<string, string> Headers = new Dictionary<string, string>();
            Headers.Add("x-api-key", parameters["API_KHIPU"]);
            Headers.Add("Accept", "*/*");
            var param = new
            { };
            using (HttpResponseMessage resp = base.CallService(parameters["URL_KHIPU"] + parameters["GET_PAYMENT_BY_ID"] + oKhipu.payment_id, Constant.Verbs.GET, param, Headers))
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