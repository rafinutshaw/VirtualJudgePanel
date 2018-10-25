namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class judge_org_change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "Name", c => c.String());
            AlterColumn("dbo.Judges", "FirstName", c => c.String());
            AlterColumn("dbo.Judges", "LastName", c => c.String());
            AlterColumn("dbo.Judges", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Judges", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Judges", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Judges", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Organizations", "Name", c => c.String(nullable: false));
        }
    }
}
