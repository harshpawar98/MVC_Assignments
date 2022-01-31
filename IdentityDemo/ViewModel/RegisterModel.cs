using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.ViewModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "UserName Cant be blank")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Cant be blank")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConformPassword Cant be blank")]
        [Compare("Password",ErrorMessage ="Password and ConformPassword must be same")]
        public string ConformPassword { get; set; }
        [Required(ErrorMessage = "Email Cant be blank")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile Cant be blank")]
        public string Mobile { get; set; }
        public DateTime? DOB { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}