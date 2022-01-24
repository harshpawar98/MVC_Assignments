namespace CodeFirstApproachDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstApproachDemo.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CodeFirstApproachDemo.Models.CompanyDbContext";
        }

        protected override void Seed(CodeFirstApproachDemo.Models.CompanyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(new Models.Brand() { BrandId=1,BrandName="Samsung"});
            context.Categories.AddOrUpdate(new Models.Category() { CatId=1,CatName="Electronics" });
            context.Products.AddOrUpdate(new Models.Product() {ProductId=1,ProductName="Mobile",Quantity=10,BrandId=1,CatId=1 });
        }
    }
}
