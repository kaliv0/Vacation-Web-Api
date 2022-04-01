using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vacation.Domain.Entities;

namespace Vacation.Data
{
    public class VacationDbContext : DbContext
    {
        public VacationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected VacationDbContext()
            : base()
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //applies all configurations
            builder.ApplyConfigurationsFromAssembly(typeof(VacationDbContext).Assembly);
        }
    }
}
