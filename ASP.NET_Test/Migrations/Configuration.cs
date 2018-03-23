using ASP.NET_Test.Models;

namespace ASP.NET_Test.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ASP.NET_Test.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ASP.NET_Test.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Dayses.AddOrUpdate(
                p => p.Day,
                new Days { Day = "Friday" },
                new Days { Day = "Saturday" },
                new Days { Day = "Sunday" },
                new Days { Day = "Monday" },
                new Days { Day = "Tuesday" },
                new Days { Day = "Wednessday" },
                new Days { Day = "Thursday" }
            );
        }
    }
}
