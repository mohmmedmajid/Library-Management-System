using API_1.DTOs.CustomerTransaction;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTransactionsController : ControllerBase
    {
        private readonly ICustomerTransactionService _customerTransactionService;

        public CustomerTransactionsController(ICustomerTransactionService customerTransactionService)
        {
            _customerTransactionService = customerTransactionService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerTransactionDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int transactionId = await _customerTransactionService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = transactionId },
                    new { TransactionID = transactionId, Message = "Customer transaction created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the customer transaction", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerTransactionDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.TransactionID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _customerTransactionService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Customer transaction not found" });

                return Ok(new { Message = "Customer transaction updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the customer transaction", Details = ex.Message });
            }
        }

  
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _customerTransactionService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Customer transaction not found" });

                return Ok(new { Message = "Customer transaction deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the customer transaction", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var transaction = await _customerTransactionService.GetByIdAsync(id);

                if (transaction == null)
                    return NotFound(new { Error = "Customer transaction not found" });

                return Ok(transaction);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the customer transaction", Details = ex.Message });
            }
        }


        [HttpGet("by-customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCustomer([FromQuery] GetTransactionsByCustomerDTO dto)
        {
            try
            {
                var transactions = await _customerTransactionService.GetByCustomerAsync(dto);
                return Ok(transactions);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving customer transactions", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTransactionsDTO dto)
        {
            try
            {
                var transactions = await _customerTransactionService.GetAllAsync(dto);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving customer transactions", Details = ex.Message });
            }
        }
    }
}
