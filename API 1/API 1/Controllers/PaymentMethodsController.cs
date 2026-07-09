using API_1.DTOs.PaymentMethod;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodsController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentMethodDTO dto)
        {
            try
            {
                var paymentMethodId = await _paymentMethodService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = paymentMethodId }, new { id = paymentMethodId });
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
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePaymentMethodDTO dto)
        {
            try
            {
                if (id != dto.PaymentMethodID)
                    return BadRequest(new { message = "ID mismatch" });

                var result = await _paymentMethodService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { message = "Payment method not found" });

                return Ok(new { message = "Payment method updated successfully" });
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
                var result = await _paymentMethodService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { message = "Payment method not found" });

                return Ok(new { message = "Payment method deleted successfully" });
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
                var paymentMethod = await _paymentMethodService.GetByIdAsync(id);

                if (paymentMethod == null)
                    return NotFound(new { message = "Payment method not found" });

                return Ok(paymentMethod);
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
                var paymentMethods = await _paymentMethodService.GetAllAsync(isActive);
                return Ok(paymentMethods);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
}