using Vacation.Domain.Dtos.AchievementDtos;
using Vacation.Domain.Entities;

namespace Vacation.Domain.Mappers
{
    public static class AchievementMapper
    {
        public static GetAchievementDto ToAchievementDto(this Achievement achievement)
        {
            return new GetAchievementDto(
                 achievement.Id,
                 achievement.Name,
                 achievement.Citizen.Name);
        }

        //public static Country ToCountry(this AddOrEditCountryDto countryDto)
        //{
        //    return new Country
        //    {
        //        Name = countryDto.Name
        //    };
        //}
    }
}
