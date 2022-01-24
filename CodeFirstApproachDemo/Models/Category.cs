using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CodeFirstApproachDemo.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string CatName { get; set;}
    }
}