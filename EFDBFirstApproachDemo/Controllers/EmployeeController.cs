using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBFirstApproachDemo.Models;

namespace EFDBFirstApproachDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            List<Employee> emp = db.Employees.ToList();
            //List<Employee> emp = db.Employees.Where(temp=>temp.DeptId==1212 && temp.EmpName=="Alex").ToList();  //retrieving multiple rows conditionally
            return View(emp);
        }
        //fetch single row
        public ActionResult Details(int id)
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            Employee e = db.Employees.Where(temp => temp.EmpId == id).FirstOrDefault();
            return View(e);
        }
        //insert record
        public ActionResult Create()
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            ViewBag.Department = db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Update
        public ActionResult Update(int id)
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            Employee e=db.Employees.Where(temp => temp.EmpId == id).FirstOrDefault();
            return View(e);
        }
        [HttpPost]
        public ActionResult Update(Employee e)
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            Employee emp = db.Employees.Where(temp => temp.EmpId == e.EmpId).FirstOrDefault();
            emp.EmpId = e.EmpId;
            emp.EmpName = e.EmpName;
            emp.DeptId = e.DeptId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete Employee

        public ActionResult Delete(int id)
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            Employee e = db.Employees.Where(temp => temp.EmpId == id).FirstOrDefault();
            return View(e);
        }

        [HttpPost]
        public ActionResult Delete(Employee e)
        {
            EmployeeDetailsEntities db = new EmployeeDetailsEntities();
            Employee emp = db.Employees.Where(temp => temp.EmpId == e.EmpId).FirstOrDefault();
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}