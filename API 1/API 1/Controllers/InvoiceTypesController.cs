using API_1.DTOs.InvoiceType;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceTypesController : ControllerBase
    {
        private readonly IInvoiceTypeService _invoiceTypeService;

        public InvoiceTypesController(IInvoiceTypeService invoiceTypeService)
        {
            _invoiceTypeService = invoiceTypeService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInvoiceTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int invoiceTypeId = await _invoiceTypeService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = invoiceTypeId },
                    new { InvoiceTypeID = invoiceTypeId, Message = "Invoice type created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the invoice type", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInvoiceTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.InvoiceTypeID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _invoiceTypeService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Invoice type not found" });

                return Ok(new { Message = "Invoice type updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the invoice type", Details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _invoiceTypeService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Invoice type not found" });

                return Ok(new { Message = "Invoice type deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the invoice type", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var invoiceType = await _invoiceTypeService.GetByIdAsync(id);

                if (invoiceType == null)
                    return NotFound(new { Error = "Invoice type not found" });

                return Ok(invoiceType);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the invoice type", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] bool? isActive = null)
        {
            try
            {
                var invoiceTypes = await _invoiceTypeService.GetAllAsync(isActive);
                return Ok(invoiceTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving invoice types", Details = ex.Message });
            }
        }
    }
}
