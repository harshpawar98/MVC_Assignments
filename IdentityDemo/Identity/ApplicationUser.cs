using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityDemo.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public DateTime? Birthdate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

    }
}