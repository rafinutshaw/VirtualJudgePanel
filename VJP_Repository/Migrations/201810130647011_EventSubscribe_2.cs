namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventSubscribe_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventSubscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventSubscribes", "StudentId", "dbo.Students");
            DropForeignKey("dbo.EventSubscribes", "EventId", "dbo.Events");
            DropIndex("dbo.EventSubscribes", new[] { "EventId" });
            DropIndex("dbo.EventSubscribes", new[] { "StudentId" });
            DropTable("dbo.EventSubscribes");
        }
    }
}
