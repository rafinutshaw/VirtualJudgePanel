namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalRating_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "TotalRatings", c => c.Double(nullable: false, defaultValue: 0));
        }

        public override void Down()
        {
            DropColumn("dbo.Projects", "TotalRatings");
        }
    }
}
