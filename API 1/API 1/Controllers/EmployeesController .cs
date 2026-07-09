using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.Employee;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int employeeId = await _employeeService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = employeeId },
                    new { EmployeeID = employeeId, Message = "Employee created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the employee", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.EmployeeID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _employeeService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Employee not found" });

                return Ok(new { Message = "Employee updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the employee", Details = ex.Message });
            }
        }


        [HttpPatch("{id}/terminate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Terminate(int id, [FromBody] DateTime terminationDate)
        {
            try
            {
                bool result = await _employeeService.TerminateAsync(id, terminationDate);

                if (!result)
                    return NotFound(new { Error = "Employee not found" });

                return Ok(new { Message = "Employee terminated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while terminating the employee", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(id);

                if (employee == null)
                    return NotFound(new { Error = "Employee not found" });

                return Ok(employee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the employee", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllEmployeesDTO dto)
        {
            try
            {
                var employees = await _employeeService.GetAllAsync(dto);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving employees", Details = ex.Message });
            }
        }


        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Search([FromQuery] string searchTerm)
        {
            try
            {
                var employees = await _employeeService.SearchAsync(searchTerm);
                return Ok(employees);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while searching employees", Details = ex.Message });
            }
        }
    }
}