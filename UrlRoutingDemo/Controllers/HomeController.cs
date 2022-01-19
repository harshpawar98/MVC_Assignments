using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlRoutingDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult empDetails(int id)
        {
            var emp =new [] { 
            new { empid=1,empname="alex",deptid=101},
            new { empid=2,empname="roli",deptid=106},
            new { empid=5,empname="james",deptid=101},
            };
            string ename = "";
            foreach (var e in emp)
            {
                if (e.empid == id)
                {
                    ename = e.empname;
                }
             }
            return Content(ename);
        }

        //Id as string parameter
        public ActionResult empData(string id)
        {
            var emp = new[] {
            new { empid=1,empname="alex",deptid=101},
            new { empid=2,empname="roli",deptid=106},
            new { empid=5,empname="james",deptid=101},
            };
            int eid = 0;
            foreach (var e in emp)
            {
                if (e.empname == id)
                {
                    eid = e.empid;
                }
            }
            return Content(eid.ToString());
        }


    }
}