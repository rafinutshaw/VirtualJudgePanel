namespace VJP_Repository.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VJP_Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<VJP_Repository.VJPDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VJP_Repository.VJPDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //List<AccountType> AccountType = new List<AccountType>();
            //List<User> Users = new List<User>();

            //AccountType.Add(new AccountType() { Type = "Admin"});
            //AccountType.Add(new AccountType() { Type = "Student"});

            //Users.Add(new User()
            //{
            //    Username = "admin", Email = "admin@gmail.com", Password = "123",
            //    ImagePath = "", Gender = "Male", AccountType_Id = 1
            //});

            //context.AccountTypes.AddRange(AccountType);
            //context.Users.AddRange(Users);

            //base.Seed(context);
        }
    }
}
