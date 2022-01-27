namespace Assignment3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        DataId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.DataId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Data");
        }
    }
}
