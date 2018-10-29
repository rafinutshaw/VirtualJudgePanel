namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectCategoryEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectCategoryEvents",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        ProjectCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventId, t.ProjectCategoryId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategoryId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.ProjectCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectCategoryEvents", "ProjectCategoryId", "dbo.ProjectCategories");
            DropForeignKey("dbo.ProjectCategoryEvents", "EventId", "dbo.Events");
            DropIndex("dbo.ProjectCategoryEvents", new[] { "ProjectCategoryId" });
            DropIndex("dbo.ProjectCategoryEvents", new[] { "EventId" });
            DropTable("dbo.ProjectCategoryEvents");
        }
    }
}
