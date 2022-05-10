namespace Vacation.Domain.Dtos.AchievementDtos
{
    public class AddOrEditAchievementDto : BaseDto
    {
        public AddOrEditAchievementDto(int id, string name)
            : base(id, name)  //????
        {
        }
    }
}
