namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demoUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 60));
            DropColumn("dbo.Users", "Username");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "ImagePath");
            DropColumn("dbo.Users", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Users", "ImagePath", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
    }
}
