using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.AchievementExceptions
{
    public class NoAchievementsFound : NotFoundException
    {
        public NoAchievementsFound()
            : base(ErrorMessages.NoAchievementsFound)
        {
        }
    }
}
