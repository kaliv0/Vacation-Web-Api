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
                            .Include(p => p.City)
                            .AsQueryable();

            if (getPlaceFilter.City != null)
            {
                Places = Places.Where(p => p.City.Name.Contains(getPlaceFilter.City));
            }

            var result = await Places.ToListAsync();
            if (!result.Any())
            {
                throw new NoPlacesFoundException();
            }

            return result;
        }

        public override async Task<Place?> GetByIdAsync(int id)
        {
            return await _dbContext.Places
                            .Include(p => p.City)
                            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
