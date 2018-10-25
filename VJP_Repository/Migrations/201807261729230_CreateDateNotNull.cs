namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDateNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CreateDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
