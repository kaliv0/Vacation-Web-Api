using Microsoft.EntityFrameworkCore;

using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions.CitizenExceptions;
using Vacation.Domain.Filters;

namespace Vacation.Data.Repositories
{
    internal sealed class CitizenRepository : BaseRepository<Citizen>, ICitizenRepository
    {
        public CitizenRepository(VacationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<Citizen>> GetAllCitizensAsync(GetCitizenFilter getCitizenFilter)
        {
            var Citizens = _dbContext.Citizens
                            .Include(a => a.City)
                            .AsQueryable();

            if (getCitizenFilter.City != null)
            {
                Citizens = Citizens.Where(a => a.City.Name == getCitizenFilter.City);
            }

            var result = await Citizens.ToListAsync();
            if (!result.Any())
{
                throw new CitizenFromCityNotFoundException();
            }

            return result;
        }

        public override async Task<Citizen?> GetByIdAsync(int id)
        {
            return await _dbContext.Citizens
                            .Include(a => a.City)
                            .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
