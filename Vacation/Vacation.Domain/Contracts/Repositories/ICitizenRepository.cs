using Vacation.Domain.Entities;
using Vacation.Domain.Filters;

namespace Vacation.Domain.Contracts.Repositories
{
    public interface ICitizenRepository : IBaseRepository<Citizen>
    {
        Task<IEnumerable<Citizen>> GetAllCitizensAsync(GetCitizenFilter getCitizenFilter);
    }
}
