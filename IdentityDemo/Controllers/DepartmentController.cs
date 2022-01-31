using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityDemo.Models;

namespace IdentityDemo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult getDeptData()
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            List<Department> dp = db.Departments.ToList();
            return View(dp);
        }
    }
}