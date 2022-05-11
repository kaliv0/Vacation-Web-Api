using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.AchievementExceptions
{
    public class AchievementNotFoundException : NotFoundException
    {
        public AchievementNotFoundException()
            : base(AchievementErrorMessages.AchievementNotFound)
        {
        }
    }
}
