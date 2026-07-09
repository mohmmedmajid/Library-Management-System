using API_1.DTOs.DiscountUsageLog;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountUsageLogsController : ControllerBase
    {
        private readonly IDiscountUsageLogService _logService;

        public DiscountUsageLogsController(IDiscountUsageLogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateDiscountUsageLogDTO dto)
        {
            try
            {
                var usageId = await _logService.CreateAsync(dto);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = usageId },
                    new { UsageId = usageId, Message = "Usage log created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var log = await _logService.GetByIdAsync(id);

                if (log == null)
                    return NotFound(new { Error = "Usage log not found" });

                return Ok(log);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? usageType = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                var dto = new GetAllUsageLogsDTO
                {
                    UsageType = usageType,
                    StartDate = startDate,
                    EndDate = endDate
                };

                var logs = await _logService.GetAllAsync(dto);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("invoice/{invoiceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByInvoice(int invoiceId)
        {
            try
            {
                var logs = await _logService.GetByInvoiceAsync(invoiceId);
                return Ok(logs);
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
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCustomer(int customerId, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            try
            {
                var dto = new GetUsageByCustomerDTO
                {
                    CustomerID = customerId,
                    StartDate = startDate,
                    EndDate = endDate
                };

                var logs = await _logService.GetByCustomerAsync(dto);
                return Ok(logs);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("statistics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatistics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var dto = new GetUsageStatisticsDTO
                {
                    StartDate = startDate,
                    EndDate = endDate
                };

                var statistics = await _logService.GetUsageStatisticsAsync(dto);
                return Ok(statistics);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("top-discounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTopDiscounts([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int topCount = 10)
        {
            try
            {
                var dto = new GetTopDiscountsDTO
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    TopCount = topCount
                };

                var topDiscounts = await _logService.GetTopDiscountsAsync(dto);
                return Ok(topDiscounts);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("top-coupons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTopCoupons([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int topCount = 10)
        {
            try
            {
                var dto = new GetTopCouponsDTO
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    TopCount = topCount
                };

                var topCoupons = await _logService.GetTopCouponsAsync(dto);
                return Ok(topCoupons);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }
    }
}