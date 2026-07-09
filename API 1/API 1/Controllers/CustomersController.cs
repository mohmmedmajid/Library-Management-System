using API_1.DTOs.Customer;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

     
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDTO dto)
        {
            try
            {
                var customerId = await _customerService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = customerId }, new { id = customerId });
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

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerDTO dto)
        {
            try
            {
                if (id != dto.CustomerID)
                    return BadRequest(new { message = "ID mismatch" });

                var result = await _customerService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { message = "Customer not found" });

                return Ok(new { message = "Customer updated successfully" });
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

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _customerService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { message = "Customer not found" });

                return Ok(new { message = "Customer deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(id);

                if (customer == null)
                    return NotFound(new { message = "Customer not found" });

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool? isActive = null)
        {
            try
            {
                var customers = await _customerService.GetAllAsync(isActive);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

      
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] SearchCustomerDTO dto)
        {
            try
            {
                var customers = await _customerService.SearchAsync(dto);
                return Ok(customers);
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


        [HttpPut("update-totals")]
        public async Task<IActionResult> UpdateTotals([FromBody] UpdateCustomerTotalsDTO dto)
        {
            try
            {
                var result = await _customerService.UpdateTotalsAsync(dto);

                if (!result)
                    return NotFound(new { message = "Customer not found" });

                return Ok(new { message = "Customer totals updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}