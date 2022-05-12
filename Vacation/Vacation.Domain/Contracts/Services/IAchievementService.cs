using Vacation.Domain.Dtos.AchievementDtos;
using Vacation.Domain.Dtos.BaseDtos;
using Vacation.Domain.Filters;

namespace Vacation.Domain.Contracts.Services
{
    public interface IAchievementService
    {
        Task<IEnumerable<GetAchievementDto>> GetAllAsync(GetAchievementFilter getAchievementFilter);

        Task<GetAchievementDto> GetByIdAsync(int id);

        Task<BaseDto> AddAsync(AddOrEditAchievementDto achievementDto);

        Task UpdateAsync(int id, AddOrEditAchievementDto achievementDto);

        Task DeleteAsync(int id);
    }
}
