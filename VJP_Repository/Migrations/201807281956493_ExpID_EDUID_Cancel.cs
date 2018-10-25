namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpID_EDUID_Cancel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "EducationDetailsId");
            DropColumn("dbo.Students", "ExperienceDetailsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ExperienceDetailsId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "EducationDetailsId", c => c.Int(nullable: false));
        }
    }
}
