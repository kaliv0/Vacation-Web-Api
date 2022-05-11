using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.CityExceptions
{
    public class CitiesFromCountryNotFoundException : NotFoundException
    {
        public CitiesFromCountryNotFoundException()
            : base(CityErrorMessages.CitiesByGivenCitizenNotFound)
        {
        }
    }
}
