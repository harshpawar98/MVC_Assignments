using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantMenuAssignment.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("MyConnectionString")
        {

        }

        public DbSet<Restaurant> Restaurants {get;set;}
        public DbSet<Menu> Menus { get; set; }

    }
}