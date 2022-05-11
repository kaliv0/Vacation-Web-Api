using Microsoft.EntityFrameworkCore;
using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions.CitizenExceptions;
using Vacation.Domain.Exceptions;
using Vacation.Domain.Filters;
using Vacation.Domain.Exceptions.CountryExceptions;

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
            var result = await _dbContext.Countries
                            .Include(c => c.Cities)
                            .ToListAsync();

            if (!result.Any())
            {
                throw new NoCountriesFoundException();
            }

            return result;
        }

        public override async Task<Country?> GetByIdAsync(int id)
        {
            return await _dbContext.Countries
                            .Include(c => c.Cities)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

