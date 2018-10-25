namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating_Comment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Comments",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Comment = c.String(nullable: false),
                   UserId = c.Int(nullable: false),
                   ProjectId = c.Int(nullable: false)
               })
               .PrimaryKey(t => t.Id)
               .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
               .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
               .Index(t => t.UserId)
               .Index(t => t.ProjectId);

            CreateTable(
               "dbo.Ratings",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Ratings = c.Double(nullable: false),
                   JudgeId = c.Int(nullable: false),
                   ProjectId = c.Int(nullable: false)
               })
               .PrimaryKey(t => t.Id)
               .ForeignKey("dbo.Judges", t => t.JudgeId, cascadeDelete: true)
               .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
               .Index(t => t.JudgeId)
               .Index(t => t.ProjectId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Ratings", "JudgeId", "dbo.Judge");
            DropForeignKey("dbo.Ratings", "ProjectId", "dbo.Projects");


            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            DropIndex("dbo.Ratings", new[] { "JudgeId" });
            DropIndex("dbo.Ratings", new[] { "ProjectId" });

            DropTable("dbo.Comments");
            DropTable("dbo.Ratings");
        }
    }
}
