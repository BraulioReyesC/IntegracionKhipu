using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace IntegracionKHIPU.Services
{
    public class ConstantKhipu
    {
        internal static Dictionary<string, string> Parameters()
        {

            Dictionary<string, string> Parameters = new Dictionary<string, string>();

            Parameters.Add("API_KHIPU", ConfigurationManager.AppSettings.Get("API_KHIPU"));
            Parameters.Add("URL_KHIPU", ConfigurationManager.AppSettings.Get("URL_KHIPU"));
            Parameters.Add("GET_BANKS", ConfigurationManager.AppSettings.Get("GET_BANKS"));
            Parameters.Add("CREATE_PAYMENT", ConfigurationManager.AppSettings.Get("CREATE_PAYMENT"));
            Parameters.Add("GET_PAYMENT_BY_ID", ConfigurationManager.AppSettings.Get("GET_PAYMENT_BY_ID"));


            return Parameters;

        }
    }
}