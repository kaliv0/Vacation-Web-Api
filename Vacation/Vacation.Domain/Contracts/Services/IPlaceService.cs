using Vacation.Domain.Dtos;
using Vacation.Domain.Dtos.PlaceDtos;
using Vacation.Domain.Filters;

namespace Vacation.Domain.Contracts.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<GetPlaceDto>> GetAllAsync(GetPlaceFilter getPlaceFilter);

        Task<GetPlaceDto> GetByIdAsync(int id);

        Task<BaseDto> AddAsync(AddOrEditPlaceDto PlaceDto);

        Task UpdateAsync(int id, AddOrEditPlaceDto PlaceDto);

        Task DeleteAsync(int id);
    }
}
