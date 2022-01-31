using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityDemo.Models;

namespace IdentityDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult getEmpData(string search = "", int PageNo = 1)
        {
            EmployeeDetailsEntities db= new EmployeeDetailsEntities();
            List<Employee> emp = db.Employees.Where(temp=>temp.EmpName.Contains(search)).ToList();
            ViewBag.Search = search;

            //paging
            int NoOfRecPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(emp.Count) / Convert.ToDouble(NoOfRecPerPage)));
            int NoOfRecToSkip = (PageNo - 1) * NoOfRecPerPage;
            ViewBag.pageno = PageNo;
            ViewBag.noofpages = NoOfPages;
            emp = emp.Skip(NoOfRecToSkip).Take(NoOfRecPerPage).ToList();
            return View(emp);
        }
    }
}