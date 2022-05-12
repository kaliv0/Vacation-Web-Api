using Vacation.Domain.Dtos.BaseDtos;

namespace Vacation.Domain.Dtos.CountryDtos
{
    public class GetCountryDto : BaseDto
    {
        public IEnumerable<BaseDto> Cities { get; set; } = new HashSet<BaseDto>();
    }
}
