using API_1.DTOs.LateFee;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LateFeesController : ControllerBase
    {
        private readonly ILateFeeService _lateFeeService;

        public LateFeesController(ILateFeeService lateFeeService)
        {
            _lateFeeService = lateFeeService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateLateFeeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int lateFeeId = await _lateFeeService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = lateFeeId },
                    new { LateFeeID = lateFeeId, Message = "Late fee created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the late fee", Details = ex.Message });
            }
        }

 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLateFeeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.LateFeeID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _lateFeeService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Late fee not found" });

                return Ok(new { Message = "Late fee updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the late fee", Details = ex.Message });
            }
        }

 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _lateFeeService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Late fee not found" });

                return Ok(new { Message = "Late fee deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the late fee", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var lateFee = await _lateFeeService.GetByIdAsync(id);

                if (lateFee == null)
                    return NotFound(new { Error = "Late fee not found" });

                return Ok(lateFee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the late fee", Details = ex.Message });
            }
        }

        [HttpGet("by-customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCustomer([FromQuery] GetLateFeesByCustomerDTO dto)
        {
            try
            {
                var lateFees = await _lateFeeService.GetByCustomerAsync(dto);
                return Ok(lateFees);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving late fees", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllLateFeesDTO dto)
        {
            try
            {
                var lateFees = await _lateFeeService.GetAllAsync(dto);
                return Ok(lateFees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving late fees", Details = ex.Message });
            }
        }

 
        [HttpPost("{id}/payment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] UpdateLateFeePaymentDTO dto)
        {
            try
            {
                if (id != dto.LateFeeID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _lateFeeService.UpdatePaymentAsync(dto.LateFeeID, dto.PaymentAmount);

                if (!result)
                    return NotFound(new { Error = "Late fee not found" });

                return Ok(new { Message = "Late fee payment updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating late fee payment", Details = ex.Message });
            }
        }


        [HttpPost("{id}/waive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Waive(int id, [FromBody] WaiveLateFeeDTO dto)
        {
            try
            {
                if (id != dto.LateFeeID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _lateFeeService.WaiveAsync(dto.LateFeeID, dto.Notes);

                if (!result)
                    return NotFound(new { Error = "Late fee not found" });

                return Ok(new { Message = "Late fee waived successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while waiving the late fee", Details = ex.Message });
            }
        }
    }
}
