using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.PlaceExceptions
{
    public class NoPlacesFoundException : NotFoundException
    {
        public NoPlacesFoundException()
            : base(ErrorMessages.NoPlacesFound)
        {
        }
    }
}
