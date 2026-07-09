using API_1.DTOs.SaleReturn;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleReturnsController : ControllerBase
    {
        private readonly ISaleReturnService _saleReturnService;

        public SaleReturnsController(ISaleReturnService saleReturnService)
        {
            _saleReturnService = saleReturnService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleReturnDTO dto)
        {
            try
            {
                var saleReturnId = await _saleReturnService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = saleReturnId }, new { id = saleReturnId });
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
                var saleReturn = await _saleReturnService.GetByIdAsync(id);

                if (saleReturn == null)
                    return NotFound(new { message = "Sale return not found" });

                return Ok(saleReturn);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                var details = await _saleReturnService.GetDetailsAsync(id);
                return Ok(details);
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
                var saleReturns = await _saleReturnService.GetAllAsync(startDate, endDate);
                return Ok(saleReturns);
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

        [HttpPost("search-by-number")]
        public async Task<IActionResult> SearchByNumber([FromBody] SearchInvoiceByNumberDTO dto)
        {
            try
            {
                var result = await _saleReturnService.SearchByNumberAsync(dto);

                if (result == null)
                    return NotFound(new { message = "Invoice not found" });

                return Ok(result);
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

        [HttpPost("search-by-barcode")]
        public async Task<IActionResult> SearchByBarcode([FromBody] SearchInvoiceByBarcodeDTO dto)
        {
            try
            {
                var results = await _saleReturnService.SearchByBarcodeAsync(dto);
                return Ok(results);
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

        [HttpPost("search-by-customer-name")]
        public async Task<IActionResult> SearchByCustomerName([FromBody] SearchInvoiceByCustomerNameDTO dto)
        {
            try
            {
                var results = await _saleReturnService.SearchByCustomerNameAsync(dto);
                return Ok(results);
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

        [HttpPost("returnable-details")]
        public async Task<IActionResult> GetReturnableDetails([FromBody] GetReturnableDetailsDTO dto)
        {
            try
            {
                var results = await _saleReturnService.GetReturnableDetailsAsync(dto);
                return Ok(results);
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