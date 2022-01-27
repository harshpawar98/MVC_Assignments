namespace Assignment3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment3.Models.UserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Assignment3.Models.UserDbContext";
        }

        protected override void Seed(Assignment3.Models.UserDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //context.Datas.AddOrUpdate(new Models.Data() { Name="Alex", Email="alex123@gmail.com", Mobile="7845124578" });
        }
    }
}
