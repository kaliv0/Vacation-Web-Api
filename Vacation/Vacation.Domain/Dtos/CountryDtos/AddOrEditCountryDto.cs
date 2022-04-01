using System.ComponentModel.DataAnnotations;
using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Dtos.CountryDtos
{
    public class AddOrEditCountryDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = CountryErrorMessages.InvalidNameLength)]
        public string Name { get; set; }
    }
}
