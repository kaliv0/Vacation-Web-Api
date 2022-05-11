using Vacation.Domain.Dtos.AchievementDtos;
using Vacation.Domain.Entities;

namespace Vacation.Domain.Mappers
{
    public static class AchievementMapper
    {
        public static GetAchievementDto ToAchievementDto(this Achievement achievement)
        {
            return new GetAchievementDto
            {
                Id = achievement.Id,
                Name = achievement.Name,
                Citizen = achievement.Citizen.Name
            };
        }

        public static Achievement ToAchievement(this AddOrEditAchievementDto achievementDto)
        {
            return new Achievement
            {
                Name = achievementDto.Name
            };
        }
    }
}
