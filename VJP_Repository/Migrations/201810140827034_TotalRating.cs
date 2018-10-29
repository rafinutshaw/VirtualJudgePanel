namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "TotalRatings", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "TotalRatings");
        }
    }
}
