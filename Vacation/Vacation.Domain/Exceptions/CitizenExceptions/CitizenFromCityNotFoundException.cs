using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.CitizenExceptions
{
    public class CitizenFromCityNotFoundException : NotFoundException
    {
        public CitizenFromCityNotFoundException()
            : base(CitizenErrorMessages.CitizensFromGivenCityNotFound)
        {
        }
    }
}
