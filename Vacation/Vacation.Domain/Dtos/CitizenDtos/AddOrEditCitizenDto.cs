using System.ComponentModel.DataAnnotations;

using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Dtos.CitizenDtos
{
    public class AddOrEditCitizenDto : AddOrEditBaseDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = GeneralErrorMessages.InvalidId)]
        public int CityId { get; set; }
    }
}
