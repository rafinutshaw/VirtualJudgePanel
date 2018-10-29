namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventimgfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Imageath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Imageath");
        }
    }
}
