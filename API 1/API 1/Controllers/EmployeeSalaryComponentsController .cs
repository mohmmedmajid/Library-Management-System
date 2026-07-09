using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.EmployeeSalaryComponent;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeSalaryComponentsController : ControllerBase
    {
        private readonly IEmployeeSalaryComponentService _employeeSalaryComponentService;

        public EmployeeSalaryComponentsController(IEmployeeSalaryComponentService employeeSalaryComponentService)
        {
            _employeeSalaryComponentService = employeeSalaryComponentService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeSalaryComponentDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int componentId = await _employeeSalaryComponentService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetByEmployee),
                    new { employeeId = dto.EmployeeID },
                    new { EmployeeSalaryComponentID = componentId, Message = "Employee salary component created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the employee salary component", Details = ex.Message });
            }
        }

   
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeSalaryComponentDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.EmployeeSalaryComponentID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _employeeSalaryComponentService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Employee salary component not found" });

                return Ok(new { Message = "Employee salary component updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while updating the employee salary component", Details = ex.Message });
            }
        }

   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _employeeSalaryComponentService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Employee salary component not found" });

                return Ok(new { Message = "Employee salary component deleted successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while deleting the employee salary component", Details = ex.Message });
            }
        }


        [HttpGet("by-employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByEmployee([FromQuery] GetComponentsByEmployeeDTO dto)
        {
            try
            {
                var components = await _employeeSalaryComponentService.GetByEmployeeAsync(dto);
                return Ok(components);
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
                return StatusCode(500, new { Error = "An error occurred while retrieving employee salary components", Details = ex.Message });
            }
        }


        [HttpGet("totals/{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTotals(int employeeId)
        {
            try
            {
                var totals = await _employeeSalaryComponentService.GetTotalsAsync(employeeId);

                if (totals == null)
                    return NotFound(new { Error = "Employee not found" });

                return Ok(totals);
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
                return StatusCode(500, new { Error = "An error occurred while retrieving salary component totals", Details = ex.Message });
            }
        }
    }
}