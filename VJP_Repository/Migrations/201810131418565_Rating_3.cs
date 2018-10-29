namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating_3 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Ratings", "Project_Id", "dbo.Projects");
            //DropForeignKey("dbo.Ratings", "Judge_JudgeId", "dbo.Judges");
            //DropIndex("dbo.Ratings", new[] { "Project_Id" });
            //DropIndex("dbo.Ratings", new[] { "Judge_JudgeId" });
           
            //AddColumn("dbo.Ratings", "Ratings", c => c.Double(nullable: false));
            //AlterColumn("dbo.Ratings", "ProjectId", c => c.Int(nullable: false));
            //AlterColumn("dbo.Ratings", "JudgeId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Ratings", "JudgeId");
            //CreateIndex("dbo.Ratings", "ProjectId");
            //AddForeignKey("dbo.Ratings", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Ratings", "JudgeId", "dbo.Judges", "JudgeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Ratings", "JudgeId", "dbo.Judges");
            //DropForeignKey("dbo.Ratings", "ProjectId", "dbo.Projects");
            //DropIndex("dbo.Ratings", new[] { "ProjectId" });
            //DropIndex("dbo.Ratings", new[] { "JudgeId" });
            //AlterColumn("dbo.Ratings", "JudgeId", c => c.Int());
            //AlterColumn("dbo.Ratings", "ProjectId", c => c.Int());
            //DropColumn("dbo.Ratings", "Ratings");
           
            //CreateIndex("dbo.Ratings", "Judge_JudgeId");
            //CreateIndex("dbo.Ratings", "Project_Id");
            //AddForeignKey("dbo.Ratings", "Judge_JudgeId", "dbo.Judges", "JudgeId");
            //AddForeignKey("dbo.Ratings", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
