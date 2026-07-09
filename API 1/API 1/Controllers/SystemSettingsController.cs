using API_1.DTOs.SystemSetting;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSettingsController : ControllerBase
    {
        private readonly ISystemSettingService _systemSettingService;

        public SystemSettingsController(ISystemSettingService systemSettingService)
        {
            _systemSettingService = systemSettingService;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSystemSettingDTO dto)
        {
            try
            {
                if (id != dto.SettingID)
                    return BadRequest(new { message = "ID mismatch" });

                var result = await _systemSettingService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { message = "Setting not found" });

                return Ok(new { message = "Setting updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }


        [HttpPut("by-key")]
        public async Task<IActionResult> UpdateByKey([FromBody] UpdateSettingByKeyDTO dto)
        {
            try
            {
                var result = await _systemSettingService.UpdateByKeyAsync(dto);

                if (!result)
                    return NotFound(new { message = "Setting not found" });

                return Ok(new { message = "Setting updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _systemSettingService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { message = "Setting not found" });

                return Ok(new { message = "Setting deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var setting = await _systemSettingService.GetByIdAsync(id);

                if (setting == null)
                    return NotFound(new { message = "Setting not found" });

                return Ok(setting);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

       
        [HttpGet("by-key/{key}")]
        public async Task<IActionResult> GetByKey(string key)
        {
            try
            {
                var value = await _systemSettingService.GetByKeyAsync(key);

                if (value == null)
                    return NotFound(new { message = "Setting not found" });

                return Ok(new { key, value });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var settings = await _systemSettingService.GetAllAsync();
                return Ok(settings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
}