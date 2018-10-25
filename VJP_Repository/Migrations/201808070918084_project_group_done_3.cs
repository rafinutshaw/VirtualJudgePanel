namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class project_group_done_3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        PostingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EventId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.EventCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(nullable: false),
                        Description = c.String(),
                        StartingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ClosingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        EventName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventName, cascadeDelete: true)
                .Index(t => t.EventName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectGroups", "StudentId", "dbo.Users");
            DropForeignKey("dbo.ProjectGroups", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.EventCategories");
            DropForeignKey("dbo.Projects", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventCategories", "EventName", "dbo.Events");
            DropIndex("dbo.EventCategories", new[] { "EventName" });
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropIndex("dbo.Projects", new[] { "EventId" });
            DropIndex("dbo.ProjectGroups", new[] { "ProjectId" });
            DropIndex("dbo.ProjectGroups", new[] { "StudentId" });
            DropTable("dbo.EventCategories");
            DropTable("dbo.Events");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectGroups");
        }
    }
}
