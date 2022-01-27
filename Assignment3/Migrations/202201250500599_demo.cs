namespace Assignment3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Data", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Data", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Data", "Mobile", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Data", "Mobile", c => c.String());
            AlterColumn("dbo.Data", "Email", c => c.String());
            AlterColumn("dbo.Data", "Name", c => c.String());
        }
    }
}
