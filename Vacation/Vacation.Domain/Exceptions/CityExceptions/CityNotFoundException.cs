using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Exceptions.CityExceptions
{
    public class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException()
            : base(CityErrorMessages.CityNotFound)
        {
        }
    }
}
