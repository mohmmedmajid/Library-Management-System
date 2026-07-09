using API.Application.Services.Interfaces;
using API_1.DTOs.ReturnTransaction;
using API_1.Services.Interfaces;
using LibrarySystem.WinForms.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTransactionsController : ControllerBase
    {
        private readonly IReturnTransactionService _returnService;

        public ReturnTransactionsController(IReturnTransactionService returnService)
        {
            _returnService = returnService;
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateReturnTransactionDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int returnId = await _returnService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = returnId },
                    new { ReturnID = returnId, Message = "Return transaction created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the return transaction", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReturnTransactionDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.ReturnID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _returnService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Return transaction not found" });

                return Ok(new { Message = "Return transaction updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the return transaction", Details = ex.Message });
            }
        }

    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _returnService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Return transaction not found" });

                return Ok(new { Message = "Return transaction deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the return transaction", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var returnTransaction = await _returnService.GetByIdAsync(id);

                if (returnTransaction == null)
                    return NotFound(new { Error = "Return transaction not found" });

                return Ok(returnTransaction);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the return transaction", Details = ex.Message });
            }
        }

        [HttpGet("by-borrowing/{borrowingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByBorrowingId(int borrowingId)
        {
            try
            {
                var returnTransaction = await _returnService.GetByBorrowingIdAsync(borrowingId);

                if (returnTransaction == null)
                    return NotFound(new { Error = "Return transaction not found for this borrowing" });

                return Ok(returnTransaction);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the return transaction", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllReturnsDTO dto)
        {
            try
            {
                var returns = await _returnService.GetAllAsync(dto);
                return Ok(returns);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving return transactions", Details = ex.Message });
            }
        }

        [HttpGet("calculate/{borrowingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CalculateReturnDetails(int borrowingId, [FromQuery] DateTime returnDate)
        {
            try
            {
                var calculation = await _returnService.CalculateReturnDetailsAsync(borrowingId, returnDate);
                return Ok(calculation);
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
                return StatusCode(500, new { Error = "An error occurred while calculating return details", Details = ex.Message });
            }
        }
        [HttpPost("with-details")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWithDetails([FromBody] CreateReturnWithDetailsDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int returnId = await _returnService.CreateWithDetailsAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = returnId },
                    new { ReturnID = returnId, Message = "Return transaction created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the return transaction", Details = ex.Message });
            }
        }

    }
}
