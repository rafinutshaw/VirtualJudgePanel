namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gender1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.Students", "About", c => c.String());
            AddColumn("dbo.Judges", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Judges", "Gender");
            DropColumn("dbo.Students", "About");
            DropColumn("dbo.Students", "Gender");
        }
    }
}
