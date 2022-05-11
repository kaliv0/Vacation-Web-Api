using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.AchievementExceptions
{
    public class AchievementsByCitizenNotFoundException : NotFoundException
    {
        public AchievementsByCitizenNotFoundException()
            : base(ErrorMessages.AchievementsByGivenCitizenNotFound)
        {
        }
    }
}
