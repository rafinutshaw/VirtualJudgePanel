namespace VJP_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobApplyActivity_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobApplyActivities", "path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplyActivities", "path");
        }
    }
}
