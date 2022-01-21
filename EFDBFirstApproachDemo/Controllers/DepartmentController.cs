using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachDemo.Models;

namespace EFDBFirstApproachDemo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            List<Department> dept = db.Departments.ToList();
            return View(dept);
        }
    }
}