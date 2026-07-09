using API_1.DTOs.BorrowingDetail;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingDetailsController : ControllerBase
    {
        private readonly IBorrowingDetailService _borrowingDetailService;

        public BorrowingDetailsController(IBorrowingDetailService borrowingDetailService)
        {
            _borrowingDetailService = borrowingDetailService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBorrowingDetailDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int detailId = await _borrowingDetailService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetByBorrowingId),
                    new { borrowingId = dto.BorrowingID },
                    new { BorrowingDetailID = detailId, Message = "Borrowing detail created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the borrowing detail", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBorrowingDetailDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.BorrowingDetailID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _borrowingDetailService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Borrowing detail not found" });

                return Ok(new { Message = "Borrowing detail updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while updating the borrowing detail", Details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _borrowingDetailService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Borrowing detail not found" });

                return Ok(new { Message = "Borrowing detail deleted successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while deleting the borrowing detail", Details = ex.Message });
            }
        }


        [HttpGet("by-borrowing/{borrowingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByBorrowingId(int borrowingId)
        {
            try
            {
                var details = await _borrowingDetailService.GetByBorrowingIdAsync(borrowingId);
                return Ok(details);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving borrowing details", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var details = await _borrowingDetailService.GetAllAsync();
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving borrowing details", Details = ex.Message });
            }
        }
    }
}
