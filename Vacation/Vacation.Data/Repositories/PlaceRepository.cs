using Microsoft.EntityFrameworkCore;

using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions.PlaceExceptions;
using Vacation.Domain.Filters;

namespace Vacation.Data.Repositories
{
    internal sealed class PlaceRepository : BaseRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(VacationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<Place>> GetAllPlacesAsync(GetPlaceFilter getPlaceFilter)
        {
            var Places = _dbContext.Places
                            .Include(a => a.City)
                            .AsQueryable();

            if (getPlaceFilter.City != null)
            {
                Places = Places.Where(a => a.City.Name == getPlaceFilter.City);
            }

            var result = await Places.ToListAsync();
            if (!result.Any())
            {
                throw new PlacesInCityNotFoundException();
            }

            return result;
        }

        public override async Task<Place?> GetByIdAsync(int id)
        {
            return await _dbContext.Places
                            .Include(a => a.City)
                            .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
