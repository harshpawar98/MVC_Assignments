using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string str)
        {
            string s = "you have entered "+str;
            if (str.Equals("sample"))
            {
                string filename = str + ".pdf";
                return File(filename, "application/pdf");
            }
            else if (str.Equals("gotoabout"))
            {
                return RedirectToAction("About");
            }
            else if (str.Equals("login"))
            {
                return RedirectToAction("Login");
            }
            
            else
                   return Content(s,"text/plain");
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}