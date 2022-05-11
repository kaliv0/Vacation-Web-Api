using System.ComponentModel.DataAnnotations;
using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Dtos.CityDtos
{
    public class AddOrEditCityDto : AddOrEditBaseDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = GeneralErrorMessages.InvalidId)]
        public int CountryId { get; set; }
    }
}
