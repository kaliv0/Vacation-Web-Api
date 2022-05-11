using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions.CityExceptions
{
    public class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException()
            : base(ErrorMessages.CityNotFound)
        {
        }
    }
}
