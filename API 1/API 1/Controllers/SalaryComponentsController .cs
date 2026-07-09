using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.SalaryComponent;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryComponentsController : ControllerBase
    {
        private readonly ISalaryComponentService _salaryComponentService;

        public SalaryComponentsController(ISalaryComponentService salaryComponentService)
        {
            _salaryComponentService = salaryComponentService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateSalaryComponentDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int componentId = await _salaryComponentService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = componentId },
                    new { ComponentID = componentId, Message = "Salary component created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the salary component", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSalaryComponentDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.ComponentID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _salaryComponentService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Salary component not found" });

                return Ok(new { Message = "Salary component updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the salary component", Details = ex.Message });
            }
        }

  
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _salaryComponentService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Salary component not found" });

                return Ok(new { Message = "Salary component deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the salary component", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var component = await _salaryComponentService.GetByIdAsync(id);

                if (component == null)
                    return NotFound(new { Error = "Salary component not found" });

                return Ok(component);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the salary component", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] string? componentType = null, [FromQuery] bool? isActive = null)
        {
            try
            {
                var components = await _salaryComponentService.GetAllAsync(componentType, isActive);
                return Ok(components);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving salary components", Details = ex.Message });
            }
        }
    }
}