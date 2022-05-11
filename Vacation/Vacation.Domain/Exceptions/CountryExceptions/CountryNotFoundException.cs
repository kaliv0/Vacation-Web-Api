using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.CountryExceptions
{
    public class CountryNotFoundException : NotFoundException
    {
        public CountryNotFoundException() 
            : base(CountryErrorMessages.CountryNotFound)
        {
        }
    }
}
