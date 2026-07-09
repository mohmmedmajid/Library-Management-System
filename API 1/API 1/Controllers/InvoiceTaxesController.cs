using API_1.DTOs.InvoiceTax;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceTaxesController : ControllerBase
    {
        private readonly IInvoiceTaxService _invoiceTaxService;

        public InvoiceTaxesController(IInvoiceTaxService invoiceTaxService)
        {
            _invoiceTaxService = invoiceTaxService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInvoiceTaxDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int invoiceTaxId = await _invoiceTaxService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = invoiceTaxId },
                    new { InvoiceTaxID = invoiceTaxId, Message = "Invoice tax created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the invoice tax", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInvoiceTaxDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.InvoiceTaxID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _invoiceTaxService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Invoice tax not found" });

                return Ok(new { Message = "Invoice tax updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the invoice tax", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _invoiceTaxService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Invoice tax not found" });

                return Ok(new { Message = "Invoice tax deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the invoice tax", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var invoiceTax = await _invoiceTaxService.GetByIdAsync(id);

                if (invoiceTax == null)
                    return NotFound(new { Error = "Invoice tax not found" });

                return Ok(invoiceTax);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the invoice tax", Details = ex.Message });
            }
        }

        [HttpGet("by-invoice/{invoiceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByInvoiceId(int invoiceId)
        {
            try
            {
                var taxes = await _invoiceTaxService.GetByInvoiceIdAsync(invoiceId);
                return Ok(taxes);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving invoice taxes", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllInvoiceTaxesDTO dto)
        {
            try
            {
                var taxes = await _invoiceTaxService.GetAllAsync(dto);
                return Ok(taxes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving invoice taxes", Details = ex.Message });
            }
        }

        [HttpGet("summary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSummary([FromQuery] GetTaxSummaryDTO dto)
        {
            try
            {
                var summary = await _invoiceTaxService.GetSummaryAsync(dto);
                return Ok(summary);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving tax summary", Details = ex.Message });
            }
        }
    }
}
