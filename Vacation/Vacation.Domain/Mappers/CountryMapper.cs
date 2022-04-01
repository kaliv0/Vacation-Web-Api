using Vacation.Domain.Dtos;
using Vacation.Domain.Dtos.CountryDtos;
using Vacation.Domain.Entities;
using Vacation.Domain.Mappers;

namespace Vacation.Domain
{
    public static class CountryMapper
    {
        public static GetCountryDto ToCountryDto(this Country country)
        {
            return new GetCountryDto
            {
                Id = country.Id,
                Name = country.Name,
                Cities = country.Cities
                    .Select(c => BaseEntityTransformer<City>.ToBaseDto(c))
                    .ToList()
            };
        }

        public static Country ToCountry(this AddOrEditCountryDto countryDto)
        {
            return new Country
            {
                Name = countryDto.Name
            };
        }
    }
}
