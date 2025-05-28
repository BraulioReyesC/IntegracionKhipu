using IntegracionKHIPU.Classes;
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
                },JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Create_Payment(Khipu oKhipu)
        {
            try
            {
                return Json(new { success = true, data = ActionsKhipu.Create_Payment(oKhipu) });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    error = ex.Message,
                    stacktrace = ex.StackTrace
                });
            }
        }
        [HttpGet]
        public ActionResult Get_Payment_By_ID(string payment_id)
        {
            try
            {
                return Json(new { success = true, data = ActionsKhipu.Get_Payment_By_ID(new Khipu { payment_id = payment_id}) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    error = ex.Message,
                    stacktrace = ex.StackTrace
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
