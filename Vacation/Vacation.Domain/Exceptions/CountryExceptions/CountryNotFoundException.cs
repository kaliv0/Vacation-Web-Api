using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.CountryExceptions
{
    public class CountryNotFoundException : NotFoundException
    {
        public CountryNotFoundException() 
            : base(ErrorMessages.CountryNotFound)
        {
        }
    }
}
