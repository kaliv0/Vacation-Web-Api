using Vacation.Domain.Entities;

namespace Vacation.Domain.Contracts.Repositories
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<Country> GetCountryByIdAsync(int id);
    }
}
