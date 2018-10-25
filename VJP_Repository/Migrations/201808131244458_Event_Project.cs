namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event_Project : DbMigration
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
                        EventCategoryId = c.Int(nullable: false),
                        ProjectCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.EventCategories", t => t.EventCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategoryId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.EventCategoryId)
                .Index(t => t.ProjectCategoryId);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventCategoryEvents",
                c => new
                    {
                        EventCategory_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventCategory_Id, t.Event_Id })
                .ForeignKey("dbo.EventCategories", t => t.EventCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.EventCategory_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.ProjectCategoryEvents",
                c => new
                    {
                        ProjectCategory_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectCategory_Id, t.Event_Id })
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.ProjectCategory_Id)
                .Index(t => t.Event_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectGroups", "StudentId", "dbo.Users");
            DropForeignKey("dbo.ProjectGroups", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectCategoryId", "dbo.ProjectCategories");
            DropForeignKey("dbo.Projects", "EventCategoryId", "dbo.EventCategories");
            DropForeignKey("dbo.Projects", "EventId", "dbo.Events");
            DropForeignKey("dbo.ProjectCategoryEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.ProjectCategoryEvents", "ProjectCategory_Id", "dbo.ProjectCategories");
            DropForeignKey("dbo.EventCategoryEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.EventCategoryEvents", "EventCategory_Id", "dbo.EventCategories");
            DropIndex("dbo.ProjectCategoryEvents", new[] { "Event_Id" });
            DropIndex("dbo.ProjectCategoryEvents", new[] { "ProjectCategory_Id" });
            DropIndex("dbo.EventCategoryEvents", new[] { "Event_Id" });
            DropIndex("dbo.EventCategoryEvents", new[] { "EventCategory_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectCategoryId" });
            DropIndex("dbo.Projects", new[] { "EventCategoryId" });
            DropIndex("dbo.Projects", new[] { "EventId" });
            DropIndex("dbo.ProjectGroups", new[] { "ProjectId" });
            DropIndex("dbo.ProjectGroups", new[] { "StudentId" });
            DropTable("dbo.ProjectCategoryEvents");
            DropTable("dbo.EventCategoryEvents");
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.EventCategories");
            DropTable("dbo.Events");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectGroups");
        }
    }
}
