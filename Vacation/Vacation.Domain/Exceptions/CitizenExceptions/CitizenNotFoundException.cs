using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.CitizenExceptions
{
    public class CitizenNotFoundException : NotFoundException
    {
        public CitizenNotFoundException()
            : base(CitizenErrorMessages.CitizenNotFound)
        {
        }
    }
}
