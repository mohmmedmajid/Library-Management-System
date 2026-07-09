using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.LateFeeRule;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LateFeeRulesController : ControllerBase
    {
        private readonly ILateFeeRuleService _lateFeeRuleService;

        public LateFeeRulesController(ILateFeeRuleService lateFeeRuleService)
        {
            _lateFeeRuleService = lateFeeRuleService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateLateFeeRuleDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int ruleId = await _lateFeeRuleService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = ruleId },
                    new { RuleID = ruleId, Message = "Late fee rule created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the late fee rule", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLateFeeRuleDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.RuleID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _lateFeeRuleService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Late fee rule not found" });

                return Ok(new { Message = "Late fee rule updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the late fee rule", Details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _lateFeeRuleService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Late fee rule not found" });

                return Ok(new { Message = "Late fee rule deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the late fee rule", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var rule = await _lateFeeRuleService.GetByIdAsync(id);

                if (rule == null)
                    return NotFound(new { Error = "Late fee rule not found" });

                return Ok(rule);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the late fee rule", Details = ex.Message });
            }
        }


        [HttpGet("active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetActive()
        {
            try
            {
                var rule = await _lateFeeRuleService.GetActiveAsync();

                if (rule == null)
                    return NotFound(new { Error = "No active late fee rule found" });

                return Ok(rule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the active late fee rule", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] bool? isActive = null)
        {
            try
            {
                var rules = await _lateFeeRuleService.GetAllAsync(isActive);
                return Ok(rules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving late fee rules", Details = ex.Message });
            }
        }


        [HttpGet("calculate-fee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CalculateFee([FromQuery] DateTime expectedReturnDate, [FromQuery] DateTime actualReturnDate)
        {
            try
            {
                var (lateDays, lateFee) = await _lateFeeRuleService.CalculateFeeAsync(expectedReturnDate, actualReturnDate);

                return Ok(new
                {
                    ExpectedReturnDate = expectedReturnDate,
                    ActualReturnDate = actualReturnDate,
                    LateDays = lateDays,
                    LateFee = lateFee
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while calculating late fee", Details = ex.Message });
            }
        }
    }
}