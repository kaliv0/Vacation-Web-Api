using Vacation.Domain.Dtos.CitizenDtos;
using Vacation.Domain.Entities;

namespace Vacation.Domain.Mappers
{
    public static class CitizenMapper
    {
        public static GetCitizenDto ToCitizenDto(this Citizen citizen)
        {
            return new GetCitizenDto
            {
                Id = citizen.Id,
                Name = citizen.Name,
                City = citizen.City.Name
            };
        }

        public static Citizen ToCitizen(this AddOrEditCitizenDto citizenDto)
        {
            return new Citizen
            {
                Name = citizenDto.Name,
                CityId = citizenDto.CityId
            };
        }
    }
}
