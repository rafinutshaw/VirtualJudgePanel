namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobSectionDone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        WebUrl = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.OrganizationId)
                .ForeignKey("dbo.Users", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.JobPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(nullable: false),
                        JobCategoryId = c.Int(nullable: false),
                        FullTimeJob = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                        Address = c.String(),
                        PostingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PostedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobCategories", t => t.JobCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.PostedBy, cascadeDelete: true)
                .Index(t => t.JobCategoryId)
                .Index(t => t.PostedBy);
            
            CreateTable(
                "dbo.JobApplyActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        JobPostId = c.Int(nullable: false),
                        ApplyDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobPosts", t => t.JobPostId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.JobPostId);
            
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.ExperienceDetails", "JobTitle", c => c.String(nullable: false));
            AlterColumn("dbo.ExperienceDetails", "CompanyName", c => c.String(nullable: false));
            AlterColumn("dbo.Judges", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Judges", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "OrganizationId", "dbo.Users");
            DropForeignKey("dbo.JobPosts", "PostedBy", "dbo.Organizations");
            DropForeignKey("dbo.JobPosts", "JobCategoryId", "dbo.JobCategories");
            DropForeignKey("dbo.JobApplyActivities", "StudentId", "dbo.Students");
            DropForeignKey("dbo.JobApplyActivities", "JobPostId", "dbo.JobPosts");
            DropIndex("dbo.JobApplyActivities", new[] { "JobPostId" });
            DropIndex("dbo.JobApplyActivities", new[] { "StudentId" });
            DropIndex("dbo.JobPosts", new[] { "PostedBy" });
            DropIndex("dbo.JobPosts", new[] { "JobCategoryId" });
            DropIndex("dbo.Organizations", new[] { "OrganizationId" });
            AlterColumn("dbo.Judges", "LastName", c => c.String());
            AlterColumn("dbo.Judges", "FirstName", c => c.String());
            AlterColumn("dbo.ExperienceDetails", "CompanyName", c => c.String());
            AlterColumn("dbo.ExperienceDetails", "JobTitle", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            DropTable("dbo.JobCategories");
            DropTable("dbo.JobApplyActivities");
            DropTable("dbo.JobPosts");
            DropTable("dbo.Organizations");
        }
    }
}
