namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating_Comment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "JudgeId", "dbo.Users");
            AddForeignKey("dbo.Ratings", "JudgeId", "dbo.Judges", "JudgeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "JudgeId", "dbo.Judges");
            AddForeignKey("dbo.Ratings", "JudgeId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
