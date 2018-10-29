namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventimgfile_2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Imageath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Imageath", c => c.String());
        }
    }
}
