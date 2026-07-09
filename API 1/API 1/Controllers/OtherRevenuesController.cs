using API_1.DTOs.OtherRevenue;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherRevenuesController : ControllerBase
    {
        private readonly IOtherRevenueService _revenueService;

        public OtherRevenuesController(IOtherRevenueService revenueService)
        {
            _revenueService = revenueService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateOtherRevenueDTO dto)
        {
            try
            {
                var revenueId = await _revenueService.CreateAsync(dto);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = revenueId },
                    new { RevenueId = revenueId, Message = "Revenue created successfully" }
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOtherRevenueDTO dto)
        {
            try
            {
                if (id != dto.RevenueID)
                    return BadRequest(new { Error = "Revenue ID mismatch" });

                var result = await _revenueService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Revenue not found" });

                return NoContent();
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _revenueService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Revenue not found" });

                return NoContent();
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var revenue = await _revenueService.GetByIdAsync(id);

                if (revenue == null)
                    return NotFound(new { Error = "Revenue not found" });

                return Ok(revenue);
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
            [FromQuery] int? categoryId = null,
            [FromQuery] int? customerId = null,
            [FromQuery] string? status = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                var dto = new GetAllRevenuesDTO
                {
                    RevenueCategoryID = categoryId,
                    CustomerID = customerId,
                    Status = status,
                    StartDate = startDate,
                    EndDate = endDate
                };

                var revenues = await _revenueService.GetAllAsync(dto);
                return Ok(revenues);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("recurring")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRecurring()
        {
            try
            {
                var revenues = await _revenueService.GetRecurringRevenuesAsync();
                return Ok(revenues);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("pending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPending()
        {
            try
            {
                var revenues = await _revenueService.GetPendingRevenuesAsync();
                return Ok(revenues);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("summary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSummary([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var dto = new GetRevenueSummaryDTO
                {
                    StartDate = startDate,
                    EndDate = endDate
                };

                var summary = await _revenueService.GetRevenueSummaryAsync(dto);
                return Ok(new
                {
                    TotalAmount = summary.TotalAmount,
                    TotalCount = summary.TotalCount
                });
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