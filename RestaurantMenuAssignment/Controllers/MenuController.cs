using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantMenuAssignment.Models;

namespace RestaurantMenuAssignment.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult getMenuData(string mname="", int PageNo=1, string SortColumn = "Menu_Id", string Iconclass = "fa-sort-asc")
        {
            RestaurantDbContext db = new RestaurantDbContext();
            List<Menu> menulist = db.Menus.ToList();
            int NoOfRecPerPage = 3;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(menulist.Count) / Convert.ToDouble(NoOfRecPerPage)));
            int NoOfRecToSkip = (PageNo - 1) * NoOfRecPerPage;
            ViewBag.pageno = PageNo;
            ViewBag.noofpages = NoOfPages;
            menulist = menulist.Skip(NoOfRecToSkip).Take(NoOfRecPerPage).ToList();

            //searching
            if (mname != "")
            {
                List<Menu> mlist = db.Menus.Where(temp => temp.Menu_Name.Contains(mname)).ToList();
                int NoOfRecPerPage1 = 3;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(mlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.mname = mname;              
                return View(mlist);
            }

            //sorting
            ViewBag.sortcolumn = SortColumn;
            ViewBag.iconclass = Iconclass;

            if (ViewBag.sortcolumn == "Menu_Id")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    menulist = menulist.OrderBy(temp => temp.Menu_Id).ToList();
                else
                    menulist = menulist.OrderByDescending(temp => temp.Menu_Id).ToList();
            }
            else if (ViewBag.sortcolumn == "Menu_Name")
            {
                if (ViewBag.iconclass == "fa-sort-asc")
                    menulist = menulist.OrderBy(temp => temp.Menu_Name).ToList();
                else
                    menulist = menulist.OrderByDescending(temp => temp.Menu_Name).ToList();
            }
            return View(menulist);
        }
        public ActionResult CreateMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMenu(Menu menu)
        {
            RestaurantDbContext db = new RestaurantDbContext();
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength - 1];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength - 1);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    menu.Photo = base64String;
                }
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("getMenuData");
            }
            else {
                return View();
            }
        }

        [Route("Menu/UpdateMenu/{menuid}")]
        public ActionResult UpdateMenu(int menuid)
        {
            RestaurantDbContext db = new RestaurantDbContext();
            Menu menu = db.Menus.Where(temp=>temp.Menu_Id==menuid).FirstOrDefault();
            TempData["imgpath"] = menu.Photo;
            return View(menu);
        }

        [HttpPost]
        public ActionResult UpdateMenu(Menu menu)
        {
            RestaurantDbContext db = new RestaurantDbContext();
            Menu m = db.Menus.Where(temp => temp.Menu_Id == menu.Menu_Id).FirstOrDefault();
            m.Menu_Name = menu.Menu_Name;

            if (menu.Photo != null)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength - 1];
                file.InputStream.Read(imgBytes, 0, file.ContentLength - 1);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                m.Photo = base64String;
            }
            else
            {
                string path = Convert.ToString(TempData["imgpath"]);
                m.Photo = path;
            }
            db.SaveChanges();
            return RedirectToAction("getMenuData");
        }

        public JsonResult DeleteMenu(int menuid)
        {
            bool result = false;
            RestaurantDbContext db = new RestaurantDbContext();
            Menu menu = db.Menus.Where(temp => temp.Menu_Id == menuid).FirstOrDefault();
            db.Menus.Remove(menu);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /*[Route("Menu/DeleteMenu/{menuid}")]
        public ActionResult DeleteMenu(int menuid)
        {
            RestaurantDbContext db = new RestaurantDbContext();
            Menu menu = db.Menus.Where(temp => temp.Menu_Id == menuid).FirstOrDefault();
            db.Menus.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("getMenuData");
        }*/
    }
}