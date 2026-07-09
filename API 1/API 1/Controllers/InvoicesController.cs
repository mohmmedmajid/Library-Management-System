using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.Invoice;
using API.Application.Services.Interfaces;

namespace API.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInvoiceDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int invoiceId = await _invoiceService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = invoiceId },
                    new { InvoiceID = invoiceId, Message = "Invoice created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the invoice", Details = ex.Message });
            }
        }

        [HttpPost("with-details")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWithDetails([FromBody] CreateInvoiceWithDetailsDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int invoiceId = await _invoiceService.CreateWithDetailsAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = invoiceId },
                    new { InvoiceID = invoiceId, Message = "Invoice with details created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the invoice", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInvoiceDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.InvoiceID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _invoiceService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Invoice not found" });

                return Ok(new { Message = "Invoice updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the invoice", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _invoiceService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Invoice not found" });

                return Ok(new { Message = "Invoice cancelled successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the invoice", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var invoice = await _invoiceService.GetByIdAsync(id);

                if (invoice == null)
                    return NotFound(new { Error = "Invoice not found" });

                return Ok(invoice);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the invoice", Details = ex.Message });
            }
        }

        [HttpGet("by-number/{invoiceNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByNumber(string invoiceNumber)
        {
            try
            {
                var invoice = await _invoiceService.GetByNumberAsync(invoiceNumber);

                if (invoice == null)
                    return NotFound(new { Error = "Invoice not found" });

                return Ok(invoice);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the invoice", Details = ex.Message });
            }
        }

        /// <summary>
        /// Get full invoice (header + details) by number
        /// </summary>
        [HttpGet("by-number/{invoiceNumber}/full")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFullByNumber(string invoiceNumber)
        {
            try
            {
                var invoice = await _invoiceService.GetFullByNumberAsync(invoiceNumber);

                if (invoice == null)
                    return NotFound(new { Error = "Invoice not found" });

                return Ok(invoice);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the invoice", Details = ex.Message });
            }
        }

        [HttpGet("{id}/with-details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWithDetails(int id)
        {
            try
            {
                var result = await _invoiceService.GetInvoiceWithDetailsAsync(id);
                return Ok(result);
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
                return StatusCode(500, new { Error = "An error occurred while retrieving the invoice", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllInvoicesDTO dto)
        {
            try
            {
                var invoices = await _invoiceService.GetAllAsync(dto);
                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving invoices", Details = ex.Message });
            }
        }
    }
}