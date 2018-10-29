namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventCategoryCancel : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Events", "EventCategory_Id", "dbo.EventCategories");
            //DropIndex("dbo.Events", new[] { "EventCategory_Id" });
            //DropColumn("dbo.Events", "EventCategory_Id");
            //DropColumn("dbo.EventCategories", "CategoryName");
        }

        public override void Down()
        {
            //AddColumn("dbo.EventCategories", "CategoryName", c => c.String(nullable: false));
            //AddColumn("dbo.Events", "EventCategory_Id", c => c.Int(nullable: false));
            //CreateIndex("dbo.Events", "EventCategory_Id");
            //AddForeignKey("dbo.Events", "EventCategory_Id", "dbo.EventCategories", "Id", cascadeDelete: true);
        }
    }
}
