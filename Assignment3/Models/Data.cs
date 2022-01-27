using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public class Data
    {
        [Key]
        [Required]
        public int DataId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z ]*$",ErrorMessage ="Use Alphabates only")]
       /* [MaxLength(20,ErrorMessage ="Name can be max 20 char")]
        [MinLength(5 ,ErrorMessage ="Name must be min 5 char")]*/
        public string Name { get; set; }
        [Required(ErrorMessage ="Email Cannot be blank")]//customize error message
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
    }
}