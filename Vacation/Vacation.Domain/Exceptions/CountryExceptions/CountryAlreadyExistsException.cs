using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.CountryExceptions
{
    public class CountryAlreadyExistsException : AlreadyExistsException
    {
        public CountryAlreadyExistsException()
            : base(CountryErrorMessages.CountryAlreadyExists)
        {
        }
    }
}
