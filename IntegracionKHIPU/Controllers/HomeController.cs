﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegracionKHIPU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReturnPay() 
        {
            return View();
        }
        public ActionResult CancelPay()
        {
            return View();
        }
    }
}