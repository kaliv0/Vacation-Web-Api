using Microsoft.AspNetCore.Mvc;

using Vacation.Domain.Constants;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos.PlaceDtos;
using Vacation.Domain.Filters;

namespace Vacation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PlacesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetPlaceFilter getPlaceFilter)
        {
            var places = await _serviceManager.PlaceService.GetAllAsync(getPlaceFilter);
            return Ok(places);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddOrEditPlaceDto PlaceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _serviceManager.PlaceService.AddAsync(PlaceDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _serviceManager.PlaceService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, [FromBody] AddOrEditPlaceDto PlaceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _serviceManager.PlaceService.UpdateAsync(id, PlaceDto);
            return Ok(SuccessMessages.EditPlace);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _serviceManager.PlaceService.DeleteAsync(id);
            return Ok(SuccessMessages.DeletePlace);
        }
    }
}

