using Microsoft.EntityFrameworkCore;

namespace Vacation.Data
{
    public class DbInitializer
    {
        private readonly VacationDbContext _dbContext;

        public DbInitializer(VacationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            await ApplyMigrationsAsync();
        }

        private async Task ApplyMigrationsAsync()
        {
            var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }
    }
}
