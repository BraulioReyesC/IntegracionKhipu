using IntegracionKHIPU.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegracionKHIPU.Controllers
{
    public class PagosController : Controller
    {
        // GET: Pagos
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get_Banks() {
            try {
                return Json(new { success = true, data = ActionsKhipu.Get_Banks() }, JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new
                {
                    success = false,
                    error = ex.Message,
                    stacktrace = ex.StackTrace
                });
            }
        }
    }
}
