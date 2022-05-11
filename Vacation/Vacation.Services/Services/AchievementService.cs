using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos;
using Vacation.Domain.Dtos.AchievementDtos;
using Vacation.Domain.Exceptions.AchievementExceptions;
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

        public async Task<BaseDto> AddAsync(AddOrEditAchievementDto countryDto)
        {
            //var country = countryDto.ToCountry();
            //var result = await _repositoryManager.CountryRepository.AddAsync(country);
            //return BaseEntityTransformer<Country>.ToBaseDto(result);

            return null;
        }

        public async Task DeleteAsync(int id)
        {
            //var countryToDelete = await _repositoryManager.CountryRepository.GetByIdAsync(id);
            //if (countryToDelete == null)
            //{
            //    throw new CountryNotFoundException();
            //}

            //await _repositoryManager.CountryRepository.DeleteAsync(countryToDelete);
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
            //var countryToUpdate = await _repositoryManager.CountryRepository.GetByIdAsync(id);
            //if (countryToUpdate == null)
            //{
            //    throw new CountryNotFoundException();
            //}

            //countryToUpdate.Name = countryDto.Name;
            //await _repositoryManager.CountryRepository.UpdateAsync(countryToUpdate);
        }
    }
}
