using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TempDataDemo1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            TempData["Message"] = "Hello Welcome";
            return RedirectToAction("Index2");
        }
        public ActionResult Index2()
        {
            string s = Convert.ToString(TempData["Message"]);
            ViewBag.mess = s;
            return View();
        }
    }
}