using Vacation.Domain.Constants;

namespace Vacation.Domain.Exceptions
{
    public class NoFilteredItemsException : NotFoundException
    {
        public NoFilteredItemsException()
            : base(ErrorMessages.NoItemsFound)
        {
        }
    }
}
