﻿using Vacation.Domain.Dtos;
using Vacation.Domain.Dtos.CountryDtos;
using Vacation.Domain.Entities;

namespace Vacation.Domain.Contracts.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<GetCountryDto>> GetAllAsync();

        Task<GetCountryDto> GetByIdAsync(int id);

        Task<BaseDto> AddAsync(AddOrEditCountryDto countryDto); //???

        Task UpdateAsync(int id, AddOrEditCountryDto countryDto);

        Task DeleteAsync(int id);
    }
}
