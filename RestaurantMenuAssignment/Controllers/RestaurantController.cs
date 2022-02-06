using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantMenuAssignment.Models;

namespace RestaurantMenuAssignment.Controllers
{
    public class RestaurantController : Controller
    {    
        public ActionResult getRestaurantData(string rname="", string city="", string mname="", int PageNo=1, string SortColumn="Restaurant_Id", string Iconclass="fa-sort-asc")
        {
            RestaurantDbContext db = new RestaurantDbContext();
            List<Restaurant> restaurantlist = db.Restaurants.ToList();
            int NoOfRecPerPage = 7;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(restaurantlist.Count) / Convert.ToDouble(NoOfRecPerPage)));
            int NoOfRecToSkip = (PageNo - 1) * NoOfRecPerPage;
            ViewBag.pageno = PageNo;
            ViewBag.noofpages = NoOfPages;
            restaurantlist = restaurantlist.Skip(NoOfRecToSkip).Take(NoOfRecPerPage).ToList();

            //searching
            if (city != "" && mname != "" && rname != "")
            {
                List<Restaurant> rlist = db.Restaurants.Where(temp => temp.City.Contains(city) && temp.Menu.Menu_Name.Contains(mname) && temp.Restaurant_Name.Contains(rname)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(rlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.rname = rname;
                ViewBag.mname = mname;
                ViewBag.city = city;
                return View(rlist);
            }

            else if (city != "" && mname != "")
            {
                List<Restaurant> rlist = db.Restaurants.Where(temp => temp.Menu.Menu_Name.Contains(mname) && temp.City.Contains(city)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(rlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.mname = mname;
                ViewBag.city = city;
                return View(rlist);
            }

            else if (city != "" && rname != "")
            {
                List<Restaurant> rlist = db.Restaurants.Where(temp => temp.Restaurant_Name.Contains(rname) && temp.City.Contains(city)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(rlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.rname = rname;
                ViewBag.city = city;
                return View(rlist);
            }

            else if (city != "")
            {
                List<Restaurant> rlist = db.Restaurants.Where(temp => temp.City.Contains(city)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(rlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.city = city;
                return View(rlist);
            }
            else if (mname != "")
            {
                List<Restaurant> rlist = db.Restaurants.Where(temp => temp.Menu.Menu_Name.Contains(mname)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(rlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.mname = mname;
                return View(rlist);
            }
            
            else if (rname != "")
                 {
                    List<Restaurant> rlist = db.Restaurants.Where(temp => temp.Restaurant_Name.Contains(rname)).ToList();
                    int NoOfRecPerPage1 = 7;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(rlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                    int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                    ViewBag.pageno = PageNo;
                    ViewBag.noofpages = NoOfPages1;
                    ViewBag.rname = rname;
                    return View(rlist);
                  }
            //sorting
            ViewBag.sortcolumn = SortColumn;
            ViewBag.iconclass = Iconclass;

            if (ViewBag.sortcolumn == "Restaurant_Id")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    restaurantlist = restaurantlist.OrderBy(temp => temp.Restaurant_Id).ToList();
                else
                    restaurantlist = restaurantlist.OrderByDescending(temp => temp.Restaurant_Id).ToList();
            }
            else if (ViewBag.sortcolumn == "Restaurant_Name")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    restaurantlist = restaurantlist.OrderBy(temp => temp.Restaurant_Name).ToList();
                else
                    restaurantlist = restaurantlist.OrderByDescending(temp => temp.Restaurant_Name).ToList();
            }
            else if (ViewBag.sortcolumn == "Address")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    restaurantlist = restaurantlist.OrderBy(temp => temp.Address).ToList();
                else
                    restaurantlist = restaurantlist.OrderByDescending(temp => temp.Address).ToList();
            }
            else if (ViewBag.sortcolumn == "City")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    restaurantlist = restaurantlist.OrderBy(temp => temp.City).ToList();
                else
                    restaurantlist = restaurantlist.OrderByDescending(temp => temp.City).ToList();
            }
            else if (ViewBag.sortcolumn == "Mobile")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    restaurantlist = restaurantlist.OrderBy(temp => temp.Mobile).ToList();
                else
                    restaurantlist = restaurantlist.OrderByDescending(temp => temp.Mobile).ToList();
            }
            else if (ViewBag.sortcolumn == "Menu_Id")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    restaurantlist = restaurantlist.OrderBy(temp => temp.Menu.Menu_Name).ToList();
                else
                    restaurantlist = restaurantlist.OrderByDescending(temp => temp.Menu.Menu_Name).ToList();
            }

            return View(restaurantlist);
        }

        [Route("Restaurant/DetailsOfRestaurant/{restaurantid}")]
        public ActionResult DetailsOfRestaurant(int restaurantid)
        {
            RestaurantDbContext db = new RestaurantDbContext();
            Restaurant restaurant = db.Restaurants.Where(temp => temp.Restaurant_Id == restaurantid).FirstOrDefault();
            return View(restaurant);
        }

        public ActionResult CreateRestaurant()
        {
            RestaurantDbContext db = new RestaurantDbContext();
            ViewBag.menu = db.Menus.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateRestaurant(Restaurant restaurant)
        {
            RestaurantDbContext db = new RestaurantDbContext();
            if (ModelState.IsValid)
            {
                
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("getRestaurantData");
            }
            else
            {
                ViewBag.menu = db.Menus.ToList();
                return View();
                
            }

        }

        [Route("Restaurant/UpdateRestaurant/{restaurantid}")]
        public ActionResult UpdateRestaurant(int restaurantid)
        {
            RestaurantDbContext db = new RestaurantDbContext();
            Restaurant rest = db.Restaurants.Where(temp => temp.Restaurant_Id == restaurantid).FirstOrDefault();
            ViewBag.menu = db.Menus.ToList();
            return View(rest);
        }

        [HttpPost]
        public ActionResult UpdateRestaurant(Restaurant restaurant)
        {
            RestaurantDbContext db = new RestaurantDbContext();
            Restaurant rest = db.Restaurants.Where(temp => temp.Restaurant_Id == restaurant.Restaurant_Id).FirstOrDefault();
            rest.Restaurant_Name = restaurant.Restaurant_Name;
            rest.Address = restaurant.Address;
            rest.City = restaurant.City;
            rest.Mobile = restaurant.Mobile;
            rest.Menu_Id = restaurant.Menu_Id;
            db.SaveChanges();
            return RedirectToAction("getRestaurantData");
        }

        public JsonResult DeleteRestaurant(int restaurantid)
        {
            bool result = false;
            RestaurantDbContext db = new RestaurantDbContext();
            Restaurant restaurant = db.Restaurants.Where(temp => temp.Restaurant_Id == restaurantid).FirstOrDefault();
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }





        // [Route("Restaurant/DeleteRestaurant/{rid}")]
        /*public ActionResult DeleteRestaurant(int restaurantid)
        {
            RestaurantDbContext db = new RestaurantDbContext();
            Restaurant rest = db.Restaurants.Where(temp => temp.Restaurant_Id == restaurantid).FirstOrDefault();
            db.Restaurants.Remove(rest);
            db.SaveChanges();
            return RedirectToAction("getRestaurantData");
        }*/
    }
}