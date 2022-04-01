using Microsoft.EntityFrameworkCore;
using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Entities;

namespace Vacation.Data.Repositories
{
    internal sealed class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(VacationDbContext dbContext)
            : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _dbContext.Countries
                            .Include(c => c.Cities)
                            .ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _dbContext.Countries
                            .Include(c => c.Cities)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

