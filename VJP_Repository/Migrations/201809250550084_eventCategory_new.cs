namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventCategory_new : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "EventCategory_Id", newName: "Category_Id");
            RenameIndex(table: "dbo.Events", name: "IX_EventCategory_Id", newName: "IX_Category_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_Category_Id", newName: "IX_EventCategory_Id");
            RenameColumn(table: "dbo.Events", name: "Category_Id", newName: "EventCategory_Id");
        }
    }
}
