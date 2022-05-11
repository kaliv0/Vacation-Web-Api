using Microsoft.EntityFrameworkCore;

using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions;
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
            var citizens = _dbContext.Citizens
                            .Include(c => c.City)
                            .Include(c => c.Achievements)
                            .AsQueryable();

            if (getCitizenFilter.City != null)
            {
                citizens = citizens.Where(c => c.City.Name.Contains(getCitizenFilter.City));
            }

            var result = await citizens.ToListAsync();
            if (!result.Any())
            {
                if (getCitizenFilter.City != null)
                {
                    throw new NoFilteredItemsException();
                }

                throw new NoCitizensFoundException();
            }

            return result;
        }

        public override async Task<Citizen?> GetByIdAsync(int id)
        {
            return await _dbContext.Citizens
                            .Include(c => c.City)
                            .Include(c => c.Achievements)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
