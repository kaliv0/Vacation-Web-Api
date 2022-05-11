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
            return new GetCountryDto(
                  country.Id,
                  country.Name,
                  country.Cities
                        .Select(c => BaseEntityTransformer<City>.ToBaseDto(c))
                        .ToList());
        }

        public static Country ToCountry(this AddOrEditCountryDto countryDto)
        {
            return new Country(countryDto.Name);
        }
    }
}
