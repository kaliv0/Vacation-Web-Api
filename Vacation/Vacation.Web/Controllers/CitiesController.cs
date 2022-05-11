using Microsoft.AspNetCore.Mvc;

using Vacation.Domain.Constants.SuccessMessages;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos.CityDtos;
using Vacation.Domain.Filters;

namespace Vacation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CitiesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetCityFilter getCityFilter)
        {
            var cities = await _serviceManager.CityService.GetAllAsync(getCityFilter);
            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddOrEditCityDto cityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _serviceManager.CityService.AddAsync(cityDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _serviceManager.CityService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, [FromBody] AddOrEditCityDto cityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _serviceManager.CityService.UpdateAsync(id, cityDto);
            return Ok(CitySuccessMessages.EditCity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _serviceManager.CityService.DeleteAsync(id);
            return Ok(CitySuccessMessages.DeleteCity);
        }
    }
}
