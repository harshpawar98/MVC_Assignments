using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorViewEngineDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.CustId = 111;
            ViewBag.CustName = "Alex";
            ViewBag.Amount = 25000;
            ViewBag.Type = new List<string>() { "Saving", "Current","FD"};
            return View();
        }
    }
}