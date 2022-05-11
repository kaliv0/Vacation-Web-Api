using Microsoft.AspNetCore.Mvc;

using Vacation.Domain.Constants;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos.CitizenDtos;
using Vacation.Domain.Filters;

namespace Vacation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CitizensController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetCitizenFilter getCitizenFilter)
        {
            var citizens = await _serviceManager.CitizenService.GetAllAsync(getCitizenFilter);
            return Ok(citizens);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddOrEditCitizenDto CitizenDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _serviceManager.CitizenService.AddAsync(CitizenDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _serviceManager.CitizenService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, [FromBody] AddOrEditCitizenDto CitizenDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _serviceManager.CitizenService.UpdateAsync(id, CitizenDto);
            return Ok(SuccessMessages.EditCitizen);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _serviceManager.CitizenService.DeleteAsync(id);
            return Ok(SuccessMessages.DeleteCitizen);
        }
    }
}

