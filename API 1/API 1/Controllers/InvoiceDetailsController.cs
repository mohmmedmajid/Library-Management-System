using API_1.DTOs.InvoiceDetail;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoiceDetailsController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
        }

 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInvoiceDetailDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int detailId = await _invoiceDetailService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetByInvoiceId),
                    new { invoiceId = dto.InvoiceID },
                    new { InvoiceDetailID = detailId, Message = "Invoice detail created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the invoice detail", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInvoiceDetailDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.InvoiceDetailID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _invoiceDetailService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Invoice detail not found" });

                return Ok(new { Message = "Invoice detail updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while updating the invoice detail", Details = ex.Message });
            }
        }

  
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _invoiceDetailService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Invoice detail not found" });

                return Ok(new { Message = "Invoice detail deleted successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while deleting the invoice detail", Details = ex.Message });
            }
        }

   
        [HttpGet("by-invoice/{invoiceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByInvoiceId(int invoiceId)
        {
            try
            {
                var details = await _invoiceDetailService.GetByInvoiceIdAsync(invoiceId);
                return Ok(details);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving invoice details", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var details = await _invoiceDetailService.GetAllAsync();
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving invoice details", Details = ex.Message });
            }
        }
    }
}
