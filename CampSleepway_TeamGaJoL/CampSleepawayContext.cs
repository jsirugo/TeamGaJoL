using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CampSleepway_TeamGaJoL
{
    public class CampSleepawayContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<Cabin> Cabins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Camper>().ToTable("Campers");
            modelBuilder.Entity<Counselor>().ToTable("Counselors");
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
            .EnableSensitiveDataLogging()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter((category, level) => level >= LogLevel.Warning)));

            // Dataloggning vi använde för uppbyggnad av program, utbytt mot ovan för att spara plats i consollen
            //optionsBuilder.UseSqlServer(connectionString)
            //    .LogTo(Console.WriteLine,
            //    new[] { DbLoggerCategory.Database.Name },
            //    LogLevel.Information)
            //    .EnableSensitiveDataLogging();
        }
    }


}
