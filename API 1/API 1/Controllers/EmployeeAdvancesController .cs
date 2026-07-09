using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.EmployeeAdvance;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeAdvancesController : ControllerBase
    {
        private readonly IEmployeeAdvanceService _employeeAdvanceService;

        public EmployeeAdvancesController(IEmployeeAdvanceService employeeAdvanceService)
        {
            _employeeAdvanceService = employeeAdvanceService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeAdvanceDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int advanceId = await _employeeAdvanceService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = advanceId },
                    new { AdvanceID = advanceId, Message = "Employee advance created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the employee advance", Details = ex.Message });
            }
        }

 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeAdvanceDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.AdvanceID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _employeeAdvanceService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Employee advance not found" });

                return Ok(new { Message = "Employee advance updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while updating the employee advance", Details = ex.Message });
            }
        }


        [HttpPatch("{id}/cancel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                bool result = await _employeeAdvanceService.CancelAsync(id);

                if (!result)
                    return NotFound(new { Error = "Employee advance not found" });

                return Ok(new { Message = "Employee advance cancelled successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while cancelling the employee advance", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var advance = await _employeeAdvanceService.GetByIdAsync(id);

                if (advance == null)
                    return NotFound(new { Error = "Employee advance not found" });

                return Ok(advance);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the employee advance", Details = ex.Message });
            }
        }


        [HttpGet("by-employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByEmployee([FromQuery] GetAdvancesByEmployeeDTO dto)
        {
            try
            {
                var advances = await _employeeAdvanceService.GetByEmployeeAsync(dto);
                return Ok(advances);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving employee advances", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] string? status = null, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            try
            {
                var advances = await _employeeAdvanceService.GetAllAsync(status, startDate, endDate);
                return Ok(advances);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving employee advances", Details = ex.Message });
            }
        }
    }
}