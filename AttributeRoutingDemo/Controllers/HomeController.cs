using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttributeRoutingDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [Route("home/index")]
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("home/about")]
        public ActionResult About()
        {
            return View();
        }

        [Route("home/empDetails/{id:int?}")]
        public ActionResult empDetails(int id)
        {
            var emp = new[] {
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

        [Route("home/empData/{ename}")]
        public ActionResult empData(string ename)
        {
            var emp = new[] {
            new { empid=1,empname="alex",deptid=101},
            new { empid=2,empname="roli",deptid=106},
            new { empid=5,empname="james",deptid=101},
            };
            int eid = 0;
            foreach (var e in emp)
            {
                if (e.empname == ename)
                {
                    eid = e.empid;
                }
            }
            return Content(eid.ToString());
        }
    }
}