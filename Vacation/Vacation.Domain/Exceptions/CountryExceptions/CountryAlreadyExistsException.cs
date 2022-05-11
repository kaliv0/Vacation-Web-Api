using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.CountryExceptions
{
    public class CountryAlreadyExistsException : BadRequestException
    {
        public CountryAlreadyExistsException()
            : base(CountryErrorMessages.CountryAlreadyExists)
        {
        }
    }
}
