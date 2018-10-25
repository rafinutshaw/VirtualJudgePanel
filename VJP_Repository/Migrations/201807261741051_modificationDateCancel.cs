namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationDateCancel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ModificationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ModificationDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
