using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.AchievementExceptions
{
    public class AchievementsByCitizenNotFoundException : NotFoundException
    {
        public AchievementsByCitizenNotFoundException()
            : base(AchievementErrorMessages.AchievementsByGivenCitizenNotFound)
        {
        }
    }
}
