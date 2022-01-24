using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproachDemo.Models;

namespace CodeFirstApproachDemo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Product> p = db.Products.ToList();
            return View(p);
        }
    }
}