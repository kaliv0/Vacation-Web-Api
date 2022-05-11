using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.CityExceptions
{
    public class NoCitiesFoundException : NotFoundException
    {
        public NoCitiesFoundException()
            : base(ErrorMessages.NoCitiesFound)
        {
        }
    }
}
