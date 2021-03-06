using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CodeFirstApproachDemo.Migrations;


namespace CodeFirstApproachDemo.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(): base("MyConnetionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }
        public DbSet<Brand>Brands{get;set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}