namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Ratings = c.Double(nullable: false),
                    JudgeId = c.Int(nullable: false),
                    ProjectId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Judge", t => t.JudgeId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.Id);

        }

        public override void Down()
        {

            DropForeignKey("dbo.Ratings", "JudgeId", "dbo.Judgse");
            DropForeignKey("dbo.Ratings", "ProjectId", "dbo.Projects");

            DropIndex("dbo.Ratings", new[] { "Id" });

            DropTable("dbo.Ratings");
        }
    }
}
