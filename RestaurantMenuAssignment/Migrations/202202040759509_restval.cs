namespace RestaurantMenuAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restval : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurants", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.Restaurants", new[] { "Menu_Id" });
            AlterColumn("dbo.Restaurants", "Menu_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Restaurants", "Menu_Id");
            AddForeignKey("dbo.Restaurants", "Menu_Id", "dbo.Menus", "Menu_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.Restaurants", new[] { "Menu_Id" });
            AlterColumn("dbo.Restaurants", "Menu_Id", c => c.Int());
            CreateIndex("dbo.Restaurants", "Menu_Id");
            AddForeignKey("dbo.Restaurants", "Menu_Id", "dbo.Menus", "Menu_Id");
        }
    }
}
