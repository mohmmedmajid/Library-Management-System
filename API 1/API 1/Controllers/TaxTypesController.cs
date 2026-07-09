using API_1.DTOs.TaxType;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxTypesController : ControllerBase
    {
        private readonly ITaxTypeService _taxTypeService;

        public TaxTypesController(ITaxTypeService taxTypeService)
        {
            _taxTypeService = taxTypeService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTaxTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int taxTypeId = await _taxTypeService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = taxTypeId },
                    new { TaxTypeID = taxTypeId, Message = "Tax type created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the tax type", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTaxTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.TaxTypeID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _taxTypeService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Tax type not found" });

                return Ok(new { Message = "Tax type updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the tax type", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _taxTypeService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Tax type not found" });

                return Ok(new { Message = "Tax type deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the tax type", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var taxType = await _taxTypeService.GetByIdAsync(id);

                if (taxType == null)
                    return NotFound(new { Error = "Tax type not found" });

                return Ok(taxType);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the tax type", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] string? taxCategory = null, [FromQuery] bool? isActive = null)
        {
            try
            {
                var taxTypes = await _taxTypeService.GetAllAsync(taxCategory, isActive);
                return Ok(taxTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving tax types", Details = ex.Message });
            }
        }


        [HttpGet("by-category/{taxCategory}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetActiveByCategory(string taxCategory)
        {
            try
            {
                var taxType = await _taxTypeService.GetActiveByCategoryAsync(taxCategory);

                if (taxType == null)
                    return NotFound(new { Error = "No active tax type found for this category" });

                return Ok(taxType);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the tax type", Details = ex.Message });
            }
        }


        [HttpPost("calculate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalculateTax([FromBody] CalculateTaxDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                decimal taxAmount = await _taxTypeService.CalculateTaxAsync(dto);

                return Ok(new { TaxTypeID = dto.TaxTypeID, BaseAmount = dto.BaseAmount, TaxAmount = taxAmount });
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
                return StatusCode(500, new { Error = "An error occurred while calculating tax", Details = ex.Message });
            }
        }
    }
}
