namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating_Comment_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "JudgeId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Comments", new[] { "JudgeId" });
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            RenameColumn(table: "dbo.Comments", name: "JudgeId", newName: "User_Id");
            RenameColumn(table: "dbo.Comments", name: "ProjectId", newName: "Project_Id");
            AlterColumn("dbo.Comments", "User_Id", c => c.Int());
            AlterColumn("dbo.Comments", "Project_Id", c => c.Int());
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Comments", "Project_Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Comments", "Project_Id", "dbo.Projects", "Id");
            DropColumn("dbo.Comments", "comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "comment", c => c.String(nullable: false));
            DropForeignKey("dbo.Comments", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "Project_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            AlterColumn("dbo.Comments", "Project_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "User_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comments", name: "Project_Id", newName: "ProjectId");
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "JudgeId");
            CreateIndex("dbo.Comments", "ProjectId");
            CreateIndex("dbo.Comments", "JudgeId");
            AddForeignKey("dbo.Comments", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "JudgeId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
