using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.CountryExceptions
{
    public class NoCountriesFoundException : NotFoundException
    {
        public NoCountriesFoundException()
            : base(ErrorMessages.NoCountriesFound)
        {
        }
    }
}
