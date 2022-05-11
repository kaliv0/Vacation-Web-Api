using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.PlaceExceptions
{
    public class PlacesInCityNotFoundException : NotFoundException
    {
        public PlacesInCityNotFoundException()
            : base(ErrorMessages.PlacesInGivenCityNotFound)
        {
        }
    }
}
