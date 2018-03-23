using System.Data.Entity;

namespace ASP.NET_Test.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("ASPTestDB")
        {
            //Create database if database does not exist
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Days> Dayses { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}