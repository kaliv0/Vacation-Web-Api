namespace Vacation.Domain.Dtos.CityDtos
{
    public class GetCityDto : BaseDto
    {
        public string Country { get; set; }

        public IEnumerable<BaseDto> PlacesToVisit { get; set; } = new HashSet<BaseDto>();

        public IEnumerable<BaseDto> FamousCitizens { get; set; } = new HashSet<BaseDto>();

    }
}
