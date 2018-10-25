namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ExperienceDetailsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ExperienceDetailsId");
        }
    }
}
