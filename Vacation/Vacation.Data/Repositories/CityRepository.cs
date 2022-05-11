using Microsoft.EntityFrameworkCore;

using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions.CityExceptions;
using Vacation.Domain.Filters;

namespace Vacation.Data.Repositories
{
    internal sealed class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(VacationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync(GetCityFilter getCityFilter)
        {
            var Cities = _dbContext.Cities
                            .Include(a => a.Country)
                            .AsQueryable();

            if (getCityFilter.Country != null)
            {
                Cities = Cities.Where(a => a.Country.Name == getCityFilter.Country);
            }

            var result = await Cities.ToListAsync();
            if (!result.Any())
            {
                throw new CitiesFromCountryNotFoundException();
            }

            return result;
        }

        public override async Task<City?> GetByIdAsync(int id)
        {
            return await _dbContext.Cities
                            .Include(a => a.Country)
                            .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
