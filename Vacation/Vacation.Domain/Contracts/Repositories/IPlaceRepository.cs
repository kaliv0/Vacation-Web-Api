using Vacation.Domain.Entities;
using Vacation.Domain.Filters;

namespace Vacation.Domain.Contracts.Repositories
{
    public interface IPlaceRepository : IBaseRepository<Place>
    {
        Task<IEnumerable<Place>> GetAllPlacesAsync(GetPlaceFilter getPlaceFilter);
    }
}
