using Vacation.Domain.Dtos.CityDtos;
using Vacation.Domain.Entities;

namespace Vacation.Domain.Mappers
{
    public static class CityMapper
    {
        public static GetCityDto ToCityDto(this City city)
        {
            return new GetCityDto
            {
                Id = city.Id,
                Name = city.Name,
                Country = city.Country.Name,
                PlacesToVisit = city.PlacesToVisit
                        .Select(c => BaseEntityTransformer<Place>.ToBaseDto(c))
                        .ToList(),
                FamousCitizens = city.FamousCitizens
                        .Select(c => BaseEntityTransformer<Citizen>.ToBaseDto(c))
                        .ToList()
            };
        }

        public static City ToCity(this AddOrEditCityDto cityDto)
        {
            return new City
            {
                Name = cityDto.Name,
                CountryId = cityDto.CountryId
            };
        }
    }
}
