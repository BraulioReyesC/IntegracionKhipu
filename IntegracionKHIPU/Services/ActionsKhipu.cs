using IntegracionKHIPU.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegracionKHIPU.Services
{
    public static class ActionsKhipu
    {
        public static Khipu Get_Banks()
        {
            CoreKhipu core = new CoreKhipu();
            return core.Get_Banks();
        }
    }
}