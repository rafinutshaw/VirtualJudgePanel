namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        ImagePath = c.String(),
                        CreateDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        AccountType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account Type", t => t.AccountType_Id, cascadeDelete: true)
                .Index(t => t.AccountType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AccountType_Id", "dbo.Account Type");
            DropIndex("dbo.Users", new[] { "AccountType_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Account Type");
        }
    }
}
