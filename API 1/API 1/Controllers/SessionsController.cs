using API_1.DTOs.Session;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateSessionDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var (sessionId, sessionToken) = await _sessionService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetByToken),
                    new { },
                    new { SessionID = sessionId, SessionToken = sessionToken, Message = "Session created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the session", Details = ex.Message });
            }
        }

        [HttpPut("update-activity/{sessionToken}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateActivity(string sessionToken)
        {
            try
            {
                bool result = await _sessionService.UpdateActivityAsync(sessionToken);

                if (!result)
                    return NotFound(new { Error = "Session not found or inactive" });

                return Ok(new { Message = "Session activity updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while updating session activity", Details = ex.Message });
            }
        }

        [HttpPut("end")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> End([FromBody] EndSessionDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool result = await _sessionService.EndAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Session not found" });

                return Ok(new { Message = "Session ended successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while ending the session", Details = ex.Message });
            }
        }

        [HttpPut("end-all/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EndAllForUser(int userId)
        {
            try
            {
                bool result = await _sessionService.EndAllForUserAsync(userId);

                return Ok(new { Message = "All user sessions ended successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while ending user sessions", Details = ex.Message });
            }
        }

        [HttpGet("by-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByToken([FromQuery] GetSessionByTokenDTO dto)
        {
            try
            {
                var session = await _sessionService.GetByTokenAsync(dto);

                if (session == null)
                    return NotFound(new { Error = "Session not found" });

                return Ok(session);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the session", Details = ex.Message });
            }
        }


        [HttpGet("active/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetActiveByUser(int userId)
        {
            try
            {
                var sessions = await _sessionService.GetActiveByUserAsync(userId);
                return Ok(sessions);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving active sessions", Details = ex.Message });
            }
        }


        [HttpGet("active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                var sessions = await _sessionService.GetAllActiveAsync();
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving active sessions", Details = ex.Message });
            }
        }

        [HttpGet("history")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetHistory([FromQuery] GetSessionHistoryDTO dto)
        {
            try
            {
                var sessions = await _sessionService.GetHistoryAsync(dto);
                return Ok(sessions);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving session history", Details = ex.Message });
            }
        }

        [HttpDelete("clean-inactive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CleanInactive([FromQuery] int inactiveMinutes = 60)
        {
            try
            {
                int endedCount = await _sessionService.CleanInactiveAsync(inactiveMinutes);
                return Ok(new { Message = "Inactive sessions cleaned successfully", EndedCount = endedCount });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while cleaning inactive sessions", Details = ex.Message });
            }
        }

        [HttpDelete("clean-old")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CleanOld([FromQuery] int daysToKeep = 30)
        {
            try
            {
                int deletedCount = await _sessionService.CleanOldAsync(daysToKeep);
                return Ok(new { Message = "Old sessions cleaned successfully", DeletedCount = deletedCount });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while cleaning old sessions", Details = ex.Message });
            }
        }
    }
}