using Vacation.Domain.Dtos.PlaceDtos;
using Vacation.Domain.Entities;

namespace Vacation.Domain.Mappers
{
    public static class PlaceMapper
    {
        public static GetPlaceDto ToPlaceDto(this Place place)
        {
            return new GetPlaceDto
            {
                Id = place.Id,
                Name = place.Name,
                City = place.City.Name
            };
        }

        public static Place ToPlace(this AddOrEditPlaceDto placeDto)
        {
            return new Place
            {
                Name = placeDto.Name,
                CityId = placeDto.CityId
            };
        }
    }
}
