using API_1.DTOs.Coupon;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateCouponDTO dto)
        {
            try
            {
                var couponId = await _couponService.CreateAsync(dto);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = couponId },
                    new { CouponId = couponId, Message = "Coupon created successfully" }
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
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCouponDTO dto)
        {
            try
            {
                if (id != dto.CouponID)
                    return BadRequest(new { Error = "Coupon ID mismatch" });

                var result = await _couponService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Coupon not found" });

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
                var result = await _couponService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Coupon not found" });

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
                var coupon = await _couponService.GetByIdAsync(id);

                if (coupon == null)
                    return NotFound(new { Error = "Coupon not found" });

                return Ok(coupon);
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

        [HttpGet("code/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCode(string code)
        {
            try
            {
                var coupon = await _couponService.GetByCodeAsync(code);

                if (coupon == null)
                    return NotFound(new { Error = "Coupon not found" });

                return Ok(coupon);
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
        public async Task<IActionResult> GetAll([FromQuery] bool? isActive = null, [FromQuery] bool currentOnly = false)
        {
            try
            {
                var dto = new GetAllCouponsDTO
                {
                    IsActive = isActive,
                    CurrentOnly = currentOnly
                };

                var coupons = await _couponService.GetAllAsync(dto);
                return Ok(coupons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpGet("active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetActive()
        {
            try
            {
                var coupons = await _couponService.GetActiveCouponsAsync();
                return Ok(coupons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred", Details = ex.Message });
            }
        }

        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Validate([FromBody] ValidateCouponDTO dto)
        {
            try
            {
                var result = await _couponService.ValidateCouponAsync(dto);
                return Ok(new
                {
                    IsValid = result.IsValid,
                    Message = result.ErrorMessage
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

        [HttpPost("{id}/increment-usage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IncrementUsage(int id)
        {
            try
            {
                var result = await _couponService.IncrementUsageAsync(id);

                if (!result)
                    return NotFound(new { Error = "Coupon not found" });

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

        [HttpPost("code/{code}/calculate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Calculate(string code, [FromQuery] decimal purchaseAmount)
        {
            try
            {
                var discountAmount = await _couponService.CalculateCouponDiscountAsync(code, purchaseAmount);
                return Ok(new
                {
                    CouponCode = code,
                    PurchaseAmount = purchaseAmount,
                    DiscountAmount = discountAmount,
                    FinalAmount = purchaseAmount - discountAmount
                });
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
    }
}