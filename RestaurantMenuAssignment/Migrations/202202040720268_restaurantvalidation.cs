namespace RestaurantMenuAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restaurantvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Restaurant_Name", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Mobile", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Mobile", c => c.String());
            AlterColumn("dbo.Restaurants", "City", c => c.String());
            AlterColumn("dbo.Restaurants", "Address", c => c.String());
            AlterColumn("dbo.Restaurants", "Restaurant_Name", c => c.String());
        }
    }
}
