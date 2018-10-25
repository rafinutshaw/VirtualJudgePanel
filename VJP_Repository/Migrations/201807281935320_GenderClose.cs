namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderClose : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ImagePath", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false));
        }
    }
}
