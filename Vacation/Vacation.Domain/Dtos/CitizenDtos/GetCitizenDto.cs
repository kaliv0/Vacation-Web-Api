using Vacation.Domain.Dtos.BaseDtos;

namespace Vacation.Domain.Dtos.CitizenDtos
{
    public class GetCitizenDto : BaseDto
    {
        public string City { get; set; }

        public IEnumerable<BaseDto> Achievements { get; set; } = new HashSet<BaseDto>();

    }
}
