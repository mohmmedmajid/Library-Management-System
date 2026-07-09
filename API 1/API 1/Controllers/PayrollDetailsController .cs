using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.PayrollDetail;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollDetailsController : ControllerBase
    {
        private readonly IPayrollDetailService _payrollDetailService;

        public PayrollDetailsController(IPayrollDetailService payrollDetailService)
        {
            _payrollDetailService = payrollDetailService;
        }


        [HttpGet("by-payroll/{payrollId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByPayrollId(int payrollId)
        {
            try
            {
                var details = await _payrollDetailService.GetByPayrollIdAsync(payrollId);
                return Ok(details);
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
                return StatusCode(500, new { Error = "An error occurred while retrieving payroll details", Details = ex.Message });
            }
        }


        [HttpGet("by-employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByEmployee([FromQuery] GetDetailsByEmployeeDTO dto)
        {
            try
            {
                var details = await _payrollDetailService.GetByEmployeeAsync(dto);
                return Ok(details);
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
                return StatusCode(500, new { Error = "An error occurred while retrieving payroll details", Details = ex.Message });
            }
        }


        [HttpGet("{id}/breakdown")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBreakdown(int id)
        {
            try
            {
                var breakdown = await _payrollDetailService.GetBreakdownAsync(id);

                if (breakdown == null)
                    return NotFound(new { Error = "Payroll detail not found" });

                return Ok(breakdown);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving payroll detail breakdown", Details = ex.Message });
            }
        }
    }
}