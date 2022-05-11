using Microsoft.AspNetCore.Mvc;

using Vacation.Domain.Constants;
using Vacation.Domain.Contracts.Services;
using Vacation.Domain.Dtos.AchievementDtos;
using Vacation.Domain.Filters;

namespace Vacation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AchievementsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAchievementFilter getAchievementFilter)
        {
            var achievements = await _serviceManager.AchievementService.GetAllAsync(getAchievementFilter);
            return Ok(achievements);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddOrEditAchievementDto achievementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _serviceManager.AchievementService.AddAsync(achievementDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _serviceManager.AchievementService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, [FromBody] AddOrEditAchievementDto achievementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _serviceManager.AchievementService.UpdateAsync(id, achievementDto);
            return Ok(SuccessMessages.EditAchievement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _serviceManager.AchievementService.DeleteAsync(id);
            return Ok(SuccessMessages.DeleteAchievement);
        }
    }
}
