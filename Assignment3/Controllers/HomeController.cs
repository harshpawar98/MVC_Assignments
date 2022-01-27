using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult GetData()
        {
            UserDbContext db = new UserDbContext();
            List<Data> d = db.Datas.ToList();
            return View(d);
        }

        public ActionResult Create()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult Create(Data d)
        {
            if (ModelState.IsValid)
            {
                UserDbContext db = new UserDbContext();
                db.Datas.Add(d);
                db.SaveChanges();
                return RedirectToAction("GetData");
            }
            else
            {
                return View("Index");
            }
        }
    }
}