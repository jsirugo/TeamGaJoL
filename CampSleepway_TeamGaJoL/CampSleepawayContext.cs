using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CampSleepway_TeamGaJoL
{
    public class CampSleepawayContext :DbContext
    {
        public DbSet<Person> Persons { get; set; }


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
