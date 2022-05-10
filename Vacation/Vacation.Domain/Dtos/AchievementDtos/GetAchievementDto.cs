using Vacation.Domain.Entities;

namespace Vacation.Domain.Dtos.AchievementDtos
{
    public class GetAchievementDto : BaseDto
    {
        public Citizen Citizen { get; set; }

        public Country? Country { get; set; }
    }
}
