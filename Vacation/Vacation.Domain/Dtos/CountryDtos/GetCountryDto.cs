namespace Vacation.Domain.Dtos.CountryDtos
{
    public class GetCountryDto : BaseDto
    {
        public List<BaseDto> Cities { get; set; }
    }
}
