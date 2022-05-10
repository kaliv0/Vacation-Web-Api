using Microsoft.EntityFrameworkCore;
using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions;
using Vacation.Domain.Filters;

namespace Vacation.Data.Repositories
{
    internal sealed class AchievementRepository : BaseRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(VacationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<Achievement>> GetAllAchievementsAsync(GetAchievementFilter getAchievementFilter)
        {
            var achievements = _dbContext.Achievements
                            .Include(a => a.Citizen)
                            .AsQueryable();

            if (getAchievementFilter.Citizen != null)
            {
                achievements = achievements.Where(a => a.Citizen.Name == getAchievementFilter.Citizen);
            }

            var result = await achievements.ToListAsync();
            if (!result.Any())
            {
                throw new AchievementNotFoundException();
            }

            return result;
        }

        //public async Task<Country> GetCountryByIdAsync(int id)
        //{
        //    return await _dbContext.Countries
        //                    .Include(c => c.Cities)
        //                    .FirstOrDefaultAsync(c => c.Id == id);
        //}
    }
}