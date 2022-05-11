using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.AchievementExceptions
{
    public class AchievementByCitizenNotFoundException : NotFoundException
    {
        public AchievementByCitizenNotFoundException()
            : base(AchievementErrorMessages.AchievementsByGivenCitizenNotFound)
        {
        }
    }
}
