using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CampSleepway_TeamGaJoL
{
    public class CampSleepawayContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Counselor> Councelors { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<Cabin> Cabins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Camper>().ToTable("Campers");
            modelBuilder.Entity<Counselor>().ToTable("Councelors");
            modelBuilder.Entity<NextOfKin>().ToTable("NextOfKins");

        }
           
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("Local");

            optionsBuilder.UseSqlServer(connectionString)
                .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Name },
                LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }


}