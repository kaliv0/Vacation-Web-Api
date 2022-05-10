using Vacation.Domain.Entities;

namespace Vacation.Domain.Dtos.AchievementDtos
{
    public class GetAchievementDto : BaseDto
    {
        public GetAchievementDto(int id, string name, string citizen)
            : base(id, name)
        {
            this.Citizen = citizen;
        }

        public string Citizen { get; set; }
    }
}
