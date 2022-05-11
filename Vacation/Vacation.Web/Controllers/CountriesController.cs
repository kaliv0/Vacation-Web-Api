using Microsoft.AspNetCore.Mvc;

using Vacation.Domain.Constants.SuccessMessages;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos.CountryDtos;

namespace Vacation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CountriesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var countries = await _serviceManager.CountryService.GetAllAsync();
            return Ok(countries);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddOrEditCountryDto countryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _serviceManager.CountryService.AddAsync(countryDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _serviceManager.CountryService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, [FromBody] AddOrEditCountryDto countryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _serviceManager.CountryService.UpdateAsync(id, countryDto);
            return Ok(CountrySuccessMessages.EditCountry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _serviceManager.CountryService.DeleteAsync(id);
            return Ok(CountrySuccessMessages.DeleteCountry);
        }
    }
}
