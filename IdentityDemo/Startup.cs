using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using IdentityDemo.Identity;

[assembly: OwinStartup(typeof(IdentityDemo.Startup))]

namespace IdentityDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            this.CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            /*var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDbContext();
            var appuserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appuserStore);

            //create Admin role

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            //create Admin user
            if (userManager.FindByName("Admin") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin123@gmail.com";
                string userPassword = "admin123";
                var chkuser = userManager.Create(user,userPassword);
                if (chkuser.Succeeded)
                {
                    userManager.AddToRole(user.Id,"Admin");
                }*/
            }

            //create Manager role

            /*if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }*/

            //create Admin user
            /*if (userManager.FindByName("Manager") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "manager";
                user.Email = "manager123@gmail.com";
                string userPassword = "manager123";
                var chkuser = userManager.Create(user, userPassword);
                if (chkuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }*/

            //create Employee role

           /* if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);
            }*/


        }
    }

