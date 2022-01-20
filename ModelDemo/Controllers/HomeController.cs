using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelDemo.Models;

namespace ModelDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Product> product = new List<Product>() {

                new Product(){productid=101,productname="Earphone",price=999 },
                new Product(){productid=102,productname="Laptop",price=99999 },
                new Product(){productid=103,productname="Mouse",price=499 }
            };
            //ViewBag.Products = product;

            return View(product);
        }

        public ActionResult Details(int id)
        {
            List<Product> product = new List<Product>() {

                new Product(){productid=101,productname="Earphone",price=999 },
                new Product(){productid=102,productname="Laptop",price=99999 },
                new Product(){productid=103,productname="Mouse",price=499 }
            };

            Product matchproduct=null;
            foreach (var pr in product)
            {
                if (pr.productid == id)
                {
                    matchproduct = pr;
                }
            }
            //ViewBag.MatchProduct = matchproduct;
            return View(matchproduct);
        }

        public ActionResult Create()
        {
            return View();
        }

        //create product
        [HttpPost]
        public ActionResult Create(int productid,string productname,int price)
        {
            return View();
        }
    }
}