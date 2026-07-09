using API_1.DTOs.LoginAttempt;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAttemptsController : ControllerBase
    {
        private readonly ILoginAttemptService _loginAttemptService;

        public LoginAttemptsController(ILoginAttemptService loginAttemptService)
        {
            _loginAttemptService = loginAttemptService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Log([FromBody] LogLoginAttemptDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _loginAttemptService.LogAsync(dto);

                return Ok(new { Message = "Login attempt logged successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while logging the login attempt", Details = ex.Message });
            }
        }

        [HttpGet("is-locked/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IsAccountLocked(string username, [FromQuery] int maxFailedAttempts = 5, [FromQuery] int minutesAgo = 30)
        {
            try
            {
                bool isLocked = await _loginAttemptService.IsAccountLockedAsync(username, maxFailedAttempts, minutesAgo);
                return Ok(new { Username = username, IsLocked = isLocked });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while checking account lock status", Details = ex.Message });
            }
        }

        [HttpGet("by-username")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByUsername([FromQuery] GetLoginAttemptsByUsernameDTO dto)
        {
            try
            {
                var attempts = await _loginAttemptService.GetByUsernameAsync(dto);
                return Ok(attempts);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving login attempts", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllLoginAttemptsDTO dto)
        {
            try
            {
                var attempts = await _loginAttemptService.GetAllAsync(dto);
                return Ok(attempts);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving login attempts", Details = ex.Message });
            }
        }

        [HttpGet("stats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStats([FromQuery] GetLoginStatsDTO dto)
        {
            try
            {
                var stats = await _loginAttemptService.GetStatsAsync(dto);
                return Ok(stats);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving login statistics", Details = ex.Message });
            }
        }


        [HttpDelete("clean-old")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CleanOld([FromQuery] int daysToKeep = 90)
        {
            try
            {
                int deletedCount = await _loginAttemptService.CleanOldAsync(daysToKeep);
                return Ok(new { Message = "Old login attempts cleaned successfully", DeletedCount = deletedCount });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while cleaning old login attempts", Details = ex.Message });
            }
        }
    }
}