using Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esam.Controllers
{
    public class ExceptionController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult AccessDenied()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        [NonAction]
        public static string ExceptionHandle(Exception ex)
        {
            if (ex is MyException)
            {
                MyException mex = (MyException)ex;
                return mex.Message;
            }
            else
            {
                return "خطا در سیستم";
            }
        }
    }
}