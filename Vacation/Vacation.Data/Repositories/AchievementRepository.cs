using Microsoft.EntityFrameworkCore;

using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions;
using Vacation.Domain.Exceptions.AchievementExceptions;
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
                achievements = achievements.Where(a => a.Citizen.Name.Contains(getAchievementFilter.Citizen));
            }

            var result = await achievements.ToListAsync();
            if (!result.Any())
            {
                if (getAchievementFilter.Citizen != null)
                {
                    throw new NoFilteredItemsException();
                }

                throw new NoAchievementsFound();
            }

            return result;
        }

        public override async Task<Achievement?> GetByIdAsync(int id)
        {
            return await _dbContext.Achievements
                            .Include(a => a.Citizen)
                            .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}