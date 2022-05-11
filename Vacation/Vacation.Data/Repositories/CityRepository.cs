using Microsoft.EntityFrameworkCore;

using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions;
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
                            .Include(c => c.Country)
                            .Include(c => c.PlacesToVisit)
                            .Include(c => c.FamousCitizens)
                            .AsQueryable();

            if (getCityFilter.Country != null)
            {
                Cities = Cities.Where(c => c.Country.Name.Contains(getCityFilter.Country));
            }

            var result = await Cities.ToListAsync();
            if (!result.Any())
            {
                if (getCityFilter.Country != null)
                {
                    throw new NoFilteredItemsException();
                }

                throw new NoCitiesFoundException();
            }

            return result;
        }

        public override async Task<City?> GetByIdAsync(int id)
        {
            return await _dbContext.Cities
                            .Include(c => c.Country)
                            .Include(c => c.PlacesToVisit)
                            .Include(c => c.FamousCitizens)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
