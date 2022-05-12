using Vacation.Domain.Dtos.BaseDtos;
using Vacation.Domain.Dtos.CountryDtos;

namespace Vacation.Domain.Contracts.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<GetCountryDto>> GetAllAsync();

        Task<GetCountryDto> GetByIdAsync(int id);

        Task<BaseDto> AddAsync(AddOrEditCountryDto countryDto);

        Task UpdateAsync(int id, AddOrEditCountryDto countryDto);

        Task DeleteAsync(int id);
    }
}
