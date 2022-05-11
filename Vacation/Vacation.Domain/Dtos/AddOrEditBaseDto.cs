using System.ComponentModel.DataAnnotations;
using Vacation.Domain.Constants.ErrorMessages;

namespace Vacation.Domain.Dtos
{
    public abstract class AddOrEditBaseDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = GeneralErrorMessages.InvalidNameLength)]
        public string Name { get; set; }
    }
}
