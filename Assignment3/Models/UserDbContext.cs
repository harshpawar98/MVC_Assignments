using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Assignment3.Migrations;

namespace Assignment3.Models
{
    public class UserDbContext: DbContext
    {
        public UserDbContext() : base("MyConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserDbContext, Configuration>());
        }

        public DbSet<Data> Datas { get; set; }

    }
}