using IdentityDemo.Identity;
using IdentityDemo.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace IdentityDemo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel rm)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rm.Password);
                var user = new ApplicationUser() { UserName = rm.Username, PasswordHash = passwordHash, Email = rm.Email, PhoneNumber = rm.Mobile, Birthdate = rm.DOB, Country = rm.Country, City = rm.City, Address = rm.Address };
                IdentityResult result = userManager.Create(user);
                if (result.Succeeded)
                {
                    //role
                    userManager.AddToRole(user.Id,"Employee");

                    //login
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(),userIdentity);
                }
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid data");
                return View();
            }
        }
    }
}