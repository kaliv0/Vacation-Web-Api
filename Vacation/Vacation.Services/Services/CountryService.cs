using Vacation.Domain;
using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos;
using Vacation.Domain.Dtos.CountryDtos;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions;
using Vacation.Domain.Mappers;

namespace Vacation.Services.Services
{
    internal sealed class CountryService : ICountryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CountryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<BaseDto> AddAsync(AddOrEditCountryDto countryDto)
        {
            var country = countryDto.ToCountry();
            var result = await _repositoryManager.CountryRepository.AddAsync(country);
            return BaseEntityTransformer<Country>.ToBaseDto(result);
        }

        public async Task DeleteAsync(int id)
        {
            var countryToDelete = await _repositoryManager.CountryRepository.GetByIdAsync(id);
            if (countryToDelete == null)
            {
                throw new CountryNotFoundException();
            }

            await _repositoryManager.CountryRepository.DeleteAsync(countryToDelete);
        }

        public async Task<IEnumerable<GetCountryDto>> GetAllAsync()
        {
            var countriesInDb = await _repositoryManager.CountryRepository.GetAllAsync();
            return countriesInDb.Select(c => c.ToCountryDto()).ToList();
        }

        public async Task<GetCountryDto> GetByIdAsync(int id)
        {
            var countryInDb = await _repositoryManager.CountryRepository.GetCountryByIdAsync(id);
            if (countryInDb == null)
            {
                throw new CountryNotFoundException();
            }

            return countryInDb.ToCountryDto();
        }

        public async Task UpdateAsync(int id, AddOrEditCountryDto countryDto)
        {
            var countryToUpdate = await _repositoryManager.CountryRepository.GetByIdAsync(id);
            if (countryToUpdate == null)
            {
                throw new CountryNotFoundException();
            }

            countryToUpdate.Name = countryDto.Name; 
            await _repositoryManager.CountryRepository.UpdateAsync(countryToUpdate);
        }
    }
}
