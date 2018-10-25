namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreateDate");
        }
    }
}
