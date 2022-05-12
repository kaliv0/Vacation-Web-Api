using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos.BaseDtos;
using Vacation.Domain.Dtos.CityDtos;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions.CityExceptions;
using Vacation.Domain.Exceptions.CountryExceptions;
using Vacation.Domain.Filters;
using Vacation.Domain.Mappers;

namespace Vacation.Services.Services
{
    internal sealed class CityService : ICityService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CityService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<BaseDto> AddAsync(AddOrEditCityDto cityDto)
        {
            if (!await this.CheckCountryId(cityDto.CountryId))
            {
                throw new CountryNotFoundException();
            }

            var city = cityDto.ToCity();
            var result = await _repositoryManager.CityRepository.AddAsync(city);
            return BaseEntityTransformer<City>.ToBaseDto(result);
        }

        public async Task DeleteAsync(int id)
        {
            var cityToDelete = await _repositoryManager.CityRepository.GetByIdAsync(id);
            if (cityToDelete == null)
            {
                throw new CityNotFoundException();
            }

            await _repositoryManager.CityRepository.DeleteAsync(cityToDelete);
        }

        public async Task<IEnumerable<GetCityDto>> GetAllAsync(GetCityFilter getCityFilter)
        {
            var citiesInDb = await _repositoryManager.CityRepository.GetAllCitiesAsync(getCityFilter);
            return citiesInDb.Select(a => a.ToCityDto()).ToList();
        }

        public async Task<GetCityDto> GetByIdAsync(int id)
        {
            var cityInDb = await _repositoryManager.CityRepository.GetByIdAsync(id);
            if (cityInDb == null)
            {
                throw new CityNotFoundException();
            }

            return cityInDb.ToCityDto();
        }

        public async Task UpdateAsync(int id, AddOrEditCityDto cityDto)
        {
            var cityToUpdate = await _repositoryManager.CityRepository.GetByIdAsync(id);
            if (cityToUpdate == null)
            {
                throw new CityNotFoundException();
            }
            if (!await this.CheckCountryId(cityDto .CountryId))
            {
                throw new CountryNotFoundException();
            }

            cityToUpdate.Name = cityDto.Name;
            cityToUpdate.CountryId = cityDto.CountryId;
            await _repositoryManager.CityRepository.UpdateAsync(cityToUpdate);
        }

        private async Task<bool> CheckCountryId(int id)
        {
            var countriesInDb = await _repositoryManager.CountryRepository.GetByIdAsync(id);
            return countriesInDb != null;
        }
    }
}
