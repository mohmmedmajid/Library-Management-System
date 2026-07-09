using API_1.DTOs.SalesRepresentative;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRepresentativesController : ControllerBase
    {
        private readonly ISalesRepresentativeService _salesRepService;

        public SalesRepresentativesController(ISalesRepresentativeService salesRepService)
        {
            _salesRepService = salesRepService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateSalesRepresentativeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int salesRepId = await _salesRepService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = salesRepId },
                    new { SalesRepID = salesRepId, Message = "Sales representative created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the sales representative", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSalesRepresentativeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.SalesRepID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _salesRepService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Sales representative not found" });

                return Ok(new { Message = "Sales representative updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the sales representative", Details = ex.Message });
            }
        }

  
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _salesRepService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Sales representative not found" });

                return Ok(new { Message = "Sales representative deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the sales representative", Details = ex.Message });
            }
        }

  
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var salesRep = await _salesRepService.GetByIdAsync(id);

                if (salesRep == null)
                    return NotFound(new { Error = "Sales representative not found" });

                return Ok(salesRep);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the sales representative", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] bool? isActive = null)
        {
            try
            {
                var salesReps = await _salesRepService.GetAllAsync(isActive);
                return Ok(salesReps);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving sales representatives", Details = ex.Message });
            }
        }

    
        [HttpPatch("{id}/totals")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTotals(int id, [FromBody] UpdateSalesRepTotalsDTO dto)
        {
            try
            {
                if (id != dto.SalesRepID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _salesRepService.UpdateTotalsAsync(dto.SalesRepID, dto.SalesAmount, dto.CommissionAmount);

                if (!result)
                    return NotFound(new { Error = "Sales representative not found" });

                return Ok(new { Message = "Sales representative totals updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating totals", Details = ex.Message });
            }
        }
    }
}
