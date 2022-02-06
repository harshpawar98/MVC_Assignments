using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestaurantMenuAssignment.Models
{
    public class Restaurant
    {
        [Key]
        public int Restaurant_Id { get; set; }
        [Required(ErrorMessage = "Restaurant Name Can't be blank")]
        public string Restaurant_Name { get; set; }
        [Required(ErrorMessage = "Address Can't be blank")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City Can't be blank")]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Enter Alphabates Only")]
        public string City { get; set; }
        [Required(ErrorMessage = "Mobile Number Can't be blank")]
        [RegularExpression(@"^([0-9]{10})*$", ErrorMessage ="Invalid Mobile Number")]
        public string Mobile { get; set; }
       
        public Nullable<int> Menu_Id { get; set; }
        public virtual Menu Menu { get; set; }


    }
}