using Vacation.Domain.Entities;
using Vacation.Domain.Filters;

namespace Vacation.Domain.Contracts.Repositories
{
    public interface IAchievementRepository : IBaseRepository<Achievement>
    {
        Task<IEnumerable<Achievement>> GetAllAchievementsAsync(GetAchievementFilter getAchievementFilter);
    }
}
