using System.ComponentModel.DataAnnotations;

using Vacation.Domain.Constants;
using Vacation.Domain.Dtos.BaseDtos;

namespace Vacation.Domain.Dtos.CityDtos
{
    public class AddOrEditCityDto : AddOrEditBaseDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.InvalidCountryId)]
        public int CountryId { get; set; }
    }
}
