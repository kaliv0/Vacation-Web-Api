using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos.BaseDtos;
using Vacation.Domain.Dtos.PlaceDtos;
using Vacation.Domain.Entities;
using Vacation.Domain.Exceptions.CityExceptions;
using Vacation.Domain.Exceptions.PlaceExceptions;
using Vacation.Domain.Filters;
using Vacation.Domain.Mappers;

namespace Vacation.Services.Services
{
    internal sealed class PlaceService : IPlaceService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PlaceService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<BaseDto> AddAsync(AddOrEditPlaceDto placeDto)
        {
            if (!await this.CheckCityId(placeDto.CityId))
            {
                throw new CityNotFoundException();
            }

            var place = placeDto.ToPlace();
            var result = await _repositoryManager.PlaceRepository.AddAsync(place);
            return BaseEntityTransformer<Place>.ToBaseDto(result);
        }

        public async Task DeleteAsync(int id)
        {
            var placeToDelete = await _repositoryManager.PlaceRepository.GetByIdAsync(id);
            if (placeToDelete == null)
            {
                throw new PlaceNotFoundException();
            }

            await _repositoryManager.PlaceRepository.DeleteAsync(placeToDelete);
        }

        public async Task<IEnumerable<GetPlaceDto>> GetAllAsync(GetPlaceFilter getPlaceFilter)
        {
            var placesInDb = await _repositoryManager.PlaceRepository.GetAllPlacesAsync(getPlaceFilter);
            return placesInDb.Select(a => a.ToPlaceDto()).ToList();
        }

        public async Task<GetPlaceDto> GetByIdAsync(int id)
        {
            var placeInDb = await _repositoryManager.PlaceRepository.GetByIdAsync(id);
            if (placeInDb == null)
            {
                throw new PlaceNotFoundException();
            }

            return placeInDb.ToPlaceDto();
        }

        public async Task UpdateAsync(int id, AddOrEditPlaceDto placeDto)
        {
            var placeToUpdate = await _repositoryManager.PlaceRepository.GetByIdAsync(id);
            if (placeToUpdate == null)
            {
                throw new PlaceNotFoundException();
            }
            if (!await this.CheckCityId(placeDto.CityId))
            {
                throw new CityNotFoundException();
            }

            placeToUpdate.Name = placeDto.Name;
            placeToUpdate.CityId = placeDto.CityId;
            await _repositoryManager.PlaceRepository.UpdateAsync(placeToUpdate);
        }

        private async Task<bool> CheckCityId(int id)
        {
            var citiesInDb = await _repositoryManager.CityRepository.GetByIdAsync(id);
            return citiesInDb != null;
        }
    }
}
