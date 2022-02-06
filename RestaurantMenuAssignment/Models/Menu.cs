using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestaurantMenuAssignment.Models
{
    public class Menu
    {
        [Key]
        public int Menu_Id { get; set; }
        [Required(ErrorMessage = "Menu  Can't be blank")]
        public string Menu_Name { get; set; }
        public string Photo { get; set; }
    }
}