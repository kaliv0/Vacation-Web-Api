using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.PlaceExceptions
{
    public class PlaceNotFoundException : NotFoundException
    {
        public PlaceNotFoundException()
            : base(ErrorMessages.PlaceNotFound)
        {
        }
    }
}
