namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Project_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "PostedBy", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "PostedBy");
            AddForeignKey("dbo.Projects", "PostedBy", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "PostedBy", "dbo.Students");
            DropIndex("dbo.Projects", new[] { "PostedBy" });
            DropColumn("dbo.Projects", "PostedBy");
        }
    }
}
