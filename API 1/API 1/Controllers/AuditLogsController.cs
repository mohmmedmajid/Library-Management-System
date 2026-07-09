using API_1.DTOs.AuditLog;
using API_1.Models;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogsController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpPost]
        public async Task<IActionResult> Log([FromBody] CreateAuditLogDTO dto)
        {
            try
            {
                await _auditLogService.LogAsync(dto);
                return Ok(new { message = "Audit log created successfully" });
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

        [HttpPost("by-user")]
        public async Task<IActionResult> GetByUser([FromBody] GetAuditLogByUserDTO dto)
        {
            try
            {
                var logs = await _auditLogService.GetByUserAsync(dto);
                return Ok(logs);
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

        [HttpPost("by-table")]
        public async Task<IActionResult> GetByTable([FromBody] GetAuditLogByTableDTO dto)
        {
            try
            {
                var logs = await _auditLogService.GetByTableAsync(dto);
                return Ok(logs);
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

        [HttpPost("all")]
        public async Task<IActionResult> GetAll([FromBody] GetAllAuditLogsDTO dto)
        {
            try
            {
                var logs = await _auditLogService.GetAllAsync(dto);
                return Ok(logs);
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

       
        [HttpDelete("delete-old")]
        public async Task<IActionResult> DeleteOld([FromBody] DeleteOldAuditLogsDTO dto)
        {
            try
            {
                var deletedCount = await _auditLogService.DeleteOldAsync(dto);
                return Ok(new { message = $"{deletedCount} old audit logs deleted successfully", deletedCount });
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
    }
}
