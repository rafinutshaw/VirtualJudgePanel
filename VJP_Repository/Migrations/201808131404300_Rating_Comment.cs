namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating_Comment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "JudgeId", "dbo.Users");
            AddColumn("dbo.Ratings", "Ratings", c => c.Double(nullable: false));
            AddForeignKey("dbo.Ratings", "JudgeId", "dbo.Judges", "JudgeId", cascadeDelete: true);
            DropColumn("dbo.Ratings", "rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "rating", c => c.Double(nullable: false));
            DropForeignKey("dbo.Ratings", "JudgeId", "dbo.Judges");
            DropColumn("dbo.Ratings", "Ratings");
            AddForeignKey("dbo.Ratings", "JudgeId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
