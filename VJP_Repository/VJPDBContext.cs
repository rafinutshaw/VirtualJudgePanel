namespace VJP_Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using VJP_Entity;

    public class VJPDBContext : DbContext
    {
        // Your context has been configured to use a 'VJPDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'VJP_Repository.VJPDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'VJPDBContext' 
        // connection string in the application configuration file.
        public VJPDBContext()
            : base("name=VJPDBContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<EducationDetails> EducationDetails { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<ExperienceDetails> ExperienceDetails { get; set; }
        public DbSet<JobApplyActivity> JobApplyActivities { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<ProjectGroup> ProjectGroups { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}