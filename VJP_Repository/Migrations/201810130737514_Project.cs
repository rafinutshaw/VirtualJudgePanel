namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Project : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "EventCategoryId", "dbo.EventCategories");
            DropIndex("dbo.Projects", new[] { "EventCategoryId" });
            AddColumn("dbo.Projects", "Path", c => c.String());
            DropColumn("dbo.Projects", "EventCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "EventCategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Projects", "Path");
            CreateIndex("dbo.Projects", "EventCategoryId");
            AddForeignKey("dbo.Projects", "EventCategoryId", "dbo.EventCategories", "Id", cascadeDelete: true);
        }
    }
}
