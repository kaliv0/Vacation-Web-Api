using System.ComponentModel.DataAnnotations;

using Vacation.Domain.Constants;

namespace Vacation.Domain.Dtos
{
    public abstract class AddOrEditBaseDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = ErrorMessages.InvalidNameLength)]
        public string Name { get; set; }
    }
}
