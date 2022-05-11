using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos;
using Vacation.Domain.Dtos.CitizenDtos;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions.CitizenExceptions;
using Vacation.Domain.Exceptions.CityExceptions;
using Vacation.Domain.Exceptions.CountryExceptions;
using Vacation.Domain.Filters;
using Vacation.Domain.Mappers;

namespace Vacation.Services.Services
{
    internal sealed class CitizenService : ICitizenService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CitizenService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<BaseDto> AddAsync(AddOrEditCitizenDto citizenDto)
        {
            if (!await this.CheckCityId(citizenDto.CityId))
            {
                throw new CityNotFoundException();
            }

            var citizen = citizenDto.ToCitizen();
            var result = await _repositoryManager.CitizenRepository.AddAsync(citizen);
            return BaseEntityTransformer<Citizen>.ToBaseDto(result);
        }

        public async Task DeleteAsync(int id)
        {
            var citizenToDelete = await _repositoryManager.CitizenRepository.GetByIdAsync(id);
            if (citizenToDelete == null)
            {
                throw new CitizenNotFoundException();
            }

            await _repositoryManager.CitizenRepository.DeleteAsync(citizenToDelete);
        }

        public async Task<IEnumerable<GetCitizenDto>> GetAllAsync(GetCitizenFilter getCitizenFilter)
        {
            var citizensInDb = await _repositoryManager.CitizenRepository.GetAllCitizensAsync(getCitizenFilter);
            return citizensInDb.Select(a => a.ToCitizenDto()).ToList();
        }

        public async Task<GetCitizenDto> GetByIdAsync(int id)
        {
            var citizenInDb = await _repositoryManager.CitizenRepository.GetByIdAsync(id);
            if (citizenInDb == null)
            {
                throw new CitizenNotFoundException();
            }

            return citizenInDb.ToCitizenDto();
        }

        public async Task UpdateAsync(int id, AddOrEditCitizenDto citizenDto)
        {
            var citizenToUpdate = await _repositoryManager.CitizenRepository.GetByIdAsync(id);
            if (citizenToUpdate == null)
            {
                throw new CitizenNotFoundException();
            }
            if (!await this.CheckCityId(citizenDto.CityId))
            {
                throw new CityNotFoundException();
            }

            citizenToUpdate.Name = citizenDto.Name;
            citizenToUpdate.CityId = citizenDto.CityId;
            await _repositoryManager.CitizenRepository.UpdateAsync(citizenToUpdate);
        }

        private async Task<bool> CheckCityId(int id)
        {
            var citiesInDb = await _repositoryManager.CityRepository.GetByIdAsync(id);
            return citiesInDb != null;
        }
    }
}
