namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventCategoryEvents", "EventCategory_Id", "dbo.EventCategories");
            DropForeignKey("dbo.EventCategoryEvents", "Event_Id", "dbo.Events");
            DropIndex("dbo.EventCategoryEvents", new[] { "EventCategory_Id" });
            DropIndex("dbo.EventCategoryEvents", new[] { "Event_Id" });
            AddColumn("dbo.Events", "EventCategory_Id", c => c.Int());
            CreateIndex("dbo.Events", "EventCategory_Id");
            AddForeignKey("dbo.Events", "EventCategory_Id", "dbo.EventCategories", "Id");
            DropTable("dbo.EventCategoryEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventCategoryEvents",
                c => new
                    {
                        EventCategory_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventCategory_Id, t.Event_Id });
            
            DropForeignKey("dbo.Events", "EventCategory_Id", "dbo.EventCategories");
            DropIndex("dbo.Events", new[] { "EventCategory_Id" });
            DropColumn("dbo.Events", "EventCategory_Id");
            CreateIndex("dbo.EventCategoryEvents", "Event_Id");
            CreateIndex("dbo.EventCategoryEvents", "EventCategory_Id");
            AddForeignKey("dbo.EventCategoryEvents", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EventCategoryEvents", "EventCategory_Id", "dbo.EventCategories", "Id", cascadeDelete: true);
        }
    }
}
