using Vacation.Domain.Dtos.BaseDtos;
using Vacation.Domain.Dtos.CityDtos;
using Vacation.Domain.Filters;

namespace Vacation.Domain.Contracts.Services
{
    public interface ICityService
    {
        Task<IEnumerable<GetCityDto>> GetAllAsync(GetCityFilter getCityFilter);

        Task<GetCityDto> GetByIdAsync(int id);

        Task<BaseDto> AddAsync(AddOrEditCityDto CityDto);

        Task UpdateAsync(int id, AddOrEditCityDto CityDto);

        Task DeleteAsync(int id);
    }
}
