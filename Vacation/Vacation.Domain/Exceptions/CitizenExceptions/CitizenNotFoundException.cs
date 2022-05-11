using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.CitizenExceptions
{
    public class CitizenNotFoundException : NotFoundException
    {
        public CitizenNotFoundException()
            : base(ErrorMessages.CitizenNotFound)
        {
        }
    }
}
