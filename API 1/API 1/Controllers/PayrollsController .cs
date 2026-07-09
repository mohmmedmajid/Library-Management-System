using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.Payroll;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollsController : ControllerBase
    {
        private readonly IPayrollService _payrollService;

        public PayrollsController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreatePayrollDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int payrollId = await _payrollService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = payrollId },
                    new { PayrollID = payrollId, Message = "Payroll created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the payroll", Details = ex.Message });
            }
        }


        [HttpPost("{id}/approve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Approve(int id, [FromBody] ApprovePayrollDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.PayrollID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _payrollService.ApproveAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Payroll not found" });

                return Ok(new { Message = "Payroll approved successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while approving the payroll", Details = ex.Message });
            }
        }

   
        [HttpPost("{id}/post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(int id, [FromBody] PostPayrollDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.PayrollID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _payrollService.PostAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Payroll not found" });

                return Ok(new { Message = "Payroll posted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while posting the payroll", Details = ex.Message });
            }
        }


        [HttpPatch("{id}/mark-as-paid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MarkAsPaid(int id, [FromBody] int paidBy)
        {
            try
            {
                bool result = await _payrollService.MarkAsPaidAsync(id, paidBy);

                if (!result)
                    return NotFound(new { Error = "Payroll not found" });

                return Ok(new { Message = "Payroll marked as paid successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while marking payroll as paid", Details = ex.Message });
            }
        }

 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _payrollService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Payroll not found" });

                return Ok(new { Message = "Payroll deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the payroll", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var payroll = await _payrollService.GetByIdAsync(id);

                if (payroll == null)
                    return NotFound(new { Error = "Payroll not found" });

                return Ok(payroll);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the payroll", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPayrollsDTO dto)
        {
            try
            {
                var payrolls = await _payrollService.GetAllAsync(dto);
                return Ok(payrolls);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving payrolls", Details = ex.Message });
            }
        }
    }
}