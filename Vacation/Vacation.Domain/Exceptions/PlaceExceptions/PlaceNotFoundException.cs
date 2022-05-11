using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.PlaceExceptions
{
    public class PlaceNotFoundException : NotFoundException
    {
        public PlaceNotFoundException()
            : base(PlaceErrorMessages.PlaceNotFound)
        {
        }
    }
}
