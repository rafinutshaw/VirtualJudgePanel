namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class STD_JUGE_EDU_EXP_Add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Degree = c.String(nullable: false),
                        Institute = c.String(nullable: false),
                        StartingDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CompletionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EducationDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Users", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.ExperienceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        CompanyName = c.String(),
                        Description = c.String(),
                        IsCurrent = c.Boolean(nullable: false),
                        Address = c.String(),
                        StartingDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CompletionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Judges",
                c => new
                    {
                        JudgeId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.JudgeId)
                .ForeignKey("dbo.Users", t => t.JudgeId)
                .Index(t => t.JudgeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Judges", "JudgeId", "dbo.Users");
            DropForeignKey("dbo.EducationDetails", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "StudentId", "dbo.Users");
            DropForeignKey("dbo.ExperienceDetails", "StudentId", "dbo.Students");
            DropIndex("dbo.Judges", new[] { "JudgeId" });
            DropIndex("dbo.ExperienceDetails", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "StudentId" });
            DropIndex("dbo.EducationDetails", new[] { "StudentId" });
            DropTable("dbo.Judges");
            DropTable("dbo.ExperienceDetails");
            DropTable("dbo.Students");
            DropTable("dbo.EducationDetails");
        }
    }
}
