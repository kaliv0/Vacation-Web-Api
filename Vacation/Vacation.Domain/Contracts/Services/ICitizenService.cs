using Vacation.Domain.Dtos.BaseDtos;
using Vacation.Domain.Dtos.CitizenDtos;
using Vacation.Domain.Filters;

namespace Vacation.Domain.Contracts.Services
{
    public interface ICitizenService
    {
        Task<IEnumerable<GetCitizenDto>> GetAllAsync(GetCitizenFilter getCitizenFilter);

        Task<GetCitizenDto> GetByIdAsync(int id);

        Task<BaseDto> AddAsync(AddOrEditCitizenDto CitizenDto);

        Task UpdateAsync(int id, AddOrEditCitizenDto CitizenDto);

        Task DeleteAsync(int id);
    }
}
