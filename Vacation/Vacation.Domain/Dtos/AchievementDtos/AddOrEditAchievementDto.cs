using System.ComponentModel.DataAnnotations;
using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Dtos.AchievementDtos
{
    public class AddOrEditAchievementDto : AddOrEditBaseDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = GeneralErrorMessages.InvalidId)]
        public int CitizenId { get; set; }
    }
}
