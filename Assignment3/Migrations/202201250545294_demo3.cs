namespace Assignment3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demo3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Data", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Data", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
