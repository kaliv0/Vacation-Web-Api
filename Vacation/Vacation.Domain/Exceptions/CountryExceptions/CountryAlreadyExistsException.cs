using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.CountryExceptions
{
    public class CountryAlreadyExistsException : BadRequestException
    {
        public CountryAlreadyExistsException()
            : base(ErrorMessages.CountryAlreadyExists)
        {
        }
    }
}
