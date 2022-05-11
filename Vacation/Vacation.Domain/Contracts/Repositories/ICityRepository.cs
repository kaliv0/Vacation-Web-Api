using Vacation.Domain.Entities;
using Vacation.Domain.Filters;

namespace Vacation.Domain.Contracts.Repositories
{
    public interface ICityRepository : IBaseRepository<City>
    {
        Task<IEnumerable<City>> GetAllCitiesAsync(GetCityFilter getCityFilter);
    }
}
