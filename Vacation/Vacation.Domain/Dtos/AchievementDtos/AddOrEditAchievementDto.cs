using System.ComponentModel.DataAnnotations;

using Vacation.Domain.Constants;

namespace Vacation.Domain.Dtos.AchievementDtos
{
    public class AddOrEditAchievementDto : AddOrEditBaseDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.InvalidCitizenId)]
        public int CitizenId { get; set; }
    }
}
