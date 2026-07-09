using API_1.DTOs.Exchange;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExchangeDTO dto)
        {
            try
            {
                var exchangeId = await _exchangeService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = exchangeId }, new { id = exchangeId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
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
                var exchange = await _exchangeService.GetByIdAsync(id);

                if (exchange == null)
                    return NotFound(new { message = "Exchange not found" });

                return Ok(exchange);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            try
            {
                var exchanges = await _exchangeService.GetAllAsync(startDate, endDate);
                return Ok(exchanges);
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
    }
}