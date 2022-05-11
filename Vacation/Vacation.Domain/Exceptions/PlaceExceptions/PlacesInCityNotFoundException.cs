using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.PlaceExceptions
{
    public class PlacesInCityNotFoundException : NotFoundException
    {
        public PlacesInCityNotFoundException()
            : base(PlaceErrorMessages.PlacesInGivenCityNotFound)
        {
        }
    }
}
