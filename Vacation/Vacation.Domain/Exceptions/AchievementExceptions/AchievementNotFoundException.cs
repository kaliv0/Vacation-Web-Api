using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.AchievementExceptions
{
    public class AchievementNotFoundException : NotFoundException
    {
        public AchievementNotFoundException()
            : base(ErrorMessages.AchievementNotFound)
        {
        }
    }
}
