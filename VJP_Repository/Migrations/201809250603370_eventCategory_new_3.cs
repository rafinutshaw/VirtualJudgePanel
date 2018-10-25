namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventCategory_new_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Category_Id", "dbo.EventCategories");
            DropIndex("dbo.Events", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Events", name: "Category_Id", newName: "EventCategory_Id");
            AlterColumn("dbo.Events", "EventCategory_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "EventCategory_Id");
            AddForeignKey("dbo.Events", "EventCategory_Id", "dbo.EventCategories", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventCategory_Id", "dbo.EventCategories");
            DropIndex("dbo.Events", new[] { "EventCategory_Id" });
            AlterColumn("dbo.Events", "EventCategory_Id", c => c.Int());
            RenameColumn(table: "dbo.Events", name: "EventCategory_Id", newName: "Category_Id");
            CreateIndex("dbo.Events", "Category_Id");
            AddForeignKey("dbo.Events", "Category_Id", "dbo.EventCategories", "Id");
        }
    }
}
