namespace RestaurantMenuAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false, identity: true),
                        Menu_Name = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Restaurant_Id = c.Int(nullable: false, identity: true),
                        Restaurant_Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Mobile = c.String(),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Restaurant_Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.Restaurants", new[] { "Menu_Id" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.Menus");
        }
    }
}
