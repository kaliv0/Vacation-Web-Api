using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.CitizenExceptions
{
    public class NoCitizensFoundException : NotFoundException
    {
        public NoCitizensFoundException()
            : base(ErrorMessages.NoCitizensFound)
        {
        }
    }
}
