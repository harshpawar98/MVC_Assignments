using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TempDataDemo1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TempData["Message"] = "Hello";
            return RedirectToAction("Index2");
        }
        public ActionResult Index2()
        {
            //TempData.Keep("Message");
            TempData.Peek("Message");
            return RedirectToAction("Index3");
        }
        public ActionResult Index3()
        {
            string s = Convert.ToString(TempData["Message"]);
            ViewBag.mess = s;
            return View();
        }
    }
}