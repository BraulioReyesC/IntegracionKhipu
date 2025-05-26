using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace IntegracionKHIPU.Classes
{
    public class Khipu
    {
        public string payment_id { get; set; }
        public string payment_url { get; set; }
        public string simplified_transfer_url { get; set; }
        public string transfer_url { get; set; }
        public string app_url { get; set; }
        public bool ready_for_terminal { get; set; }
        public List<KhipuBank> banks { get; set; } = new List<KhipuBank>();
    }

    public class KhipuBank {
        public string bank_id { get; set; }
        public string name { get; set; }
        public string message { get; set; }
        public string min_amount { get; set; }
        public string type { get; set; }
        public string parent { get; set; }
        public string logo_url { get; set; }

    }
}