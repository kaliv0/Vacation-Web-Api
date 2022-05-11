using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.CitizenExceptions
{
    public class CitizenFromCityNotFoundException : NotFoundException
    {
        public CitizenFromCityNotFoundException()
            : base(ErrorMessages.CitizensFromGivenCityNotFound)
        {
        }
    }
}
