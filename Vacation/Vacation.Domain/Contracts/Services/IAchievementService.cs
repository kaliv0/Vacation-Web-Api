using Vacation.Domain.Dtos;
using Vacation.Domain.Dtos.AchievementDtos;

namespace Vacation.Domain.Contracts.Services
{
    public interface IAchievementService
    {
        Task<IEnumerable<GetAchievementDto>> GetAllAsync();

        Task<GetAchievementDto> GetByIdAsync(int id);

        Task<BaseDto> AddAsync(AddOrEditAchievementDto achievementDto);

        Task UpdateAsync(int id, AddOrEditAchievementDto achievementDto);

        Task DeleteAsync(int id);
    }
}
