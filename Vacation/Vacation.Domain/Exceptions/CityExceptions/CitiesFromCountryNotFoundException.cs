using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.CityExceptions
{
    public class CitiesFromCountryNotFoundException : NotFoundException
    {
        public CitiesFromCountryNotFoundException()
            : base(ErrorMessages.CitiesByGivenCitizenNotFound)
        {
        }
    }
}
