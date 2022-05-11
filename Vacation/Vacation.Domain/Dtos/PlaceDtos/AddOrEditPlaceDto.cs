using System.ComponentModel.DataAnnotations;

using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Dtos.PlaceDtos
{
    public class AddOrEditPlaceDto : AddOrEditBaseDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = GeneralErrorMessages.InvalidId)]
        public int CityId { get; set; }
    }
}
