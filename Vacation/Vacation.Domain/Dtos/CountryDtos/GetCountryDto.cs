namespace Vacation.Domain.Dtos.CountryDtos
{
    public class GetCountryDto : BaseDto
    {
        public GetCountryDto(int id, string name, IEnumerable<BaseDto> cities)
            : base(id, name)
        {
            this.Cities = cities;
        }

        public IEnumerable<BaseDto> Cities { get; set; }
    }
}
