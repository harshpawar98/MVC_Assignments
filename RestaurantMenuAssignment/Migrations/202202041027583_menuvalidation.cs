namespace RestaurantMenuAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "Menu_Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "Menu_Name", c => c.String());
        }
    }
}
