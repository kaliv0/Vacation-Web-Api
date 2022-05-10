using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions
{
    public class AchievementNotFoundException : NotFoundException
    {
        public AchievementNotFoundException()
            : base(AchievementErrorMessages.AchievementsByGivenCitizenNotFound)
        {
        }
    }
}
