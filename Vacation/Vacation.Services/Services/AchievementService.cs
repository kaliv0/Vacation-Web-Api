using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos;
using Vacation.Domain.Dtos.AchievementDtos;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions.AchievementExceptions;
using Vacation.Domain.Exceptions.CitizenExceptions;
using Vacation.Domain.Filters;
using Vacation.Domain.Mappers;

namespace Vacation.Services.Services
{
    internal sealed class AchievementService : IAchievementService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AchievementService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<BaseDto> AddAsync(AddOrEditAchievementDto achievementDto)
        {
            if (!await this.CheckCitizenId(achievementDto.CitizenId))
            {
                throw new CitizenNotFoundException();
            }

            var achievement = achievementDto.ToAchievement();
            var result = await _repositoryManager.AchievementRepository.AddAsync(achievement);
            return BaseEntityTransformer<Achievement>.ToBaseDto(result);
        }

        public async Task DeleteAsync(int id)
        {
            var achievementToDelete = await _repositoryManager.AchievementRepository.GetByIdAsync(id);
            if (achievementToDelete == null)
            {
                throw new AchievementNotFoundException();
            }

            await _repositoryManager.AchievementRepository.DeleteAsync(achievementToDelete);
        }

        public async Task<IEnumerable<GetAchievementDto>> GetAllAsync(GetAchievementFilter getAchievementFilter)
        {
            var achievementsInDb = await _repositoryManager.AchievementRepository.GetAllAchievementsAsync(getAchievementFilter);
            return achievementsInDb.Select(a => a.ToAchievementDto()).ToList();
        }

        public async Task<GetAchievementDto> GetByIdAsync(int id)
        {
            var achievementInDb = await _repositoryManager.AchievementRepository.GetByIdAsync(id);
            if (achievementInDb == null)
            {
                throw new AchievementNotFoundException();
            }

            return achievementInDb.ToAchievementDto();
        }

        public async Task UpdateAsync(int id, AddOrEditAchievementDto achievementDto)
        {
            var achievementToUpdate = await _repositoryManager.AchievementRepository.GetByIdAsync(id);
            if (achievementToUpdate == null)
            {
                throw new AchievementNotFoundException();
            }
            if (!await this.CheckCitizenId(achievementDto.CitizenId))
            {
                throw new CitizenNotFoundException();
            }

            achievementToUpdate.Name = achievementDto.Name;
            achievementToUpdate.CitizenId = achievementDto.CitizenId;
            await _repositoryManager.AchievementRepository.UpdateAsync(achievementToUpdate);
        }

        private async Task<bool> CheckCitizenId(int id)
        {
            var citizensInDb = await _repositoryManager.CitizenRepository.GetByIdAsync(id);
            return citizensInDb != null;
        }
    }
}
