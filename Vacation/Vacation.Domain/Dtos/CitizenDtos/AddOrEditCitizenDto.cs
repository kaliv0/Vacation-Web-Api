﻿using System.ComponentModel.DataAnnotations;

using Vacation.Domain.Constants;
using Vacation.Domain.Dtos.BaseDtos;

namespace Vacation.Domain.Dtos.CitizenDtos
{
    public class AddOrEditCitizenDto : AddOrEditBaseDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.InvalidCityId)]
        public int CityId { get; set; }
    }
}
