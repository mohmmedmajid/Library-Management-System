using API_1.DTOs.RepCommission;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepCommissionsController : ControllerBase
    {
        private readonly IRepCommissionService _repCommissionService;

        public RepCommissionsController(IRepCommissionService repCommissionService)
        {
            _repCommissionService = repCommissionService;
        }

     
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateRepCommissionDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int commissionId = await _repCommissionService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = commissionId },
                    new { CommissionID = commissionId, Message = "Commission created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the commission", Details = ex.Message });
            }
        }

       
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRepCommissionDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.CommissionID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _repCommissionService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Commission not found" });

                return Ok(new { Message = "Commission updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the commission", Details = ex.Message });
            }
        }

      
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _repCommissionService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Commission not found" });

                return Ok(new { Message = "Commission deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the commission", Details = ex.Message });
            }
        }

       
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var commission = await _repCommissionService.GetByIdAsync(id);

                if (commission == null)
                    return NotFound(new { Error = "Commission not found" });

                return Ok(commission);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the commission", Details = ex.Message });
            }
        }

       
        [HttpGet("by-sales-rep")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBySalesRep([FromQuery] GetCommissionsBySalesRepDTO dto)
        {
            try
            {
                var commissions = await _repCommissionService.GetBySalesRepAsync(dto);
                return Ok(commissions);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving commissions", Details = ex.Message });
            }
        }

  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCommissionsDTO dto)
        {
            try
            {
                var commissions = await _repCommissionService.GetAllAsync(dto);
                return Ok(commissions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving commissions", Details = ex.Message });
            }
        }

       
        [HttpPost("{id}/mark-paid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            try
            {
                bool result = await _repCommissionService.MarkAsPaidAsync(id);

                if (!result)
                    return NotFound(new { Error = "Commission not found" });

                return Ok(new { Message = "Commission marked as paid successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while marking commission as paid", Details = ex.Message });
            }
        }

       
        [HttpGet("unpaid-total/{salesRepId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnpaidTotal(int salesRepId)
        {
            try
            {
                var result = await _repCommissionService.GetUnpaidTotalAsync(salesRepId);

                if (result == null)
                    return NotFound(new { Error = "No unpaid commissions found" });

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
                return StatusCode(500, new { Error = "An error occurred while retrieving unpaid total", Details = ex.Message });
            }
        }
    }
}
