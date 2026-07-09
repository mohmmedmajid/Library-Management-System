using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.JournalEntryDetail;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalEntryDetailsController : ControllerBase
    {
        private readonly IJournalEntryDetailService _journalEntryDetailService;

        public JournalEntryDetailsController(IJournalEntryDetailService journalEntryDetailService)
        {
            _journalEntryDetailService = journalEntryDetailService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateJournalEntryDetailDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int detailId = await _journalEntryDetailService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetByJournalEntryId),
                    new { journalEntryId = dto.JournalEntryID },
                    new { JournalEntryDetailID = detailId, Message = "Journal entry detail created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the journal entry detail", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJournalEntryDetailDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.JournalEntryDetailID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _journalEntryDetailService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Journal entry detail not found" });

                return Ok(new { Message = "Journal entry detail updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the journal entry detail", Details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _journalEntryDetailService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Journal entry detail not found" });

                return Ok(new { Message = "Journal entry detail deleted successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while deleting the journal entry detail", Details = ex.Message });
            }
        }


        [HttpGet("by-journal-entry/{journalEntryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByJournalEntryId(int journalEntryId)
        {
            try
            {
                var details = await _journalEntryDetailService.GetByJournalEntryIdAsync(journalEntryId);
                return Ok(details);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving journal entry details", Details = ex.Message });
            }
        }

        [HttpGet("by-account")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByAccount([FromQuery] GetDetailsByAccountDTO dto)
        {
            try
            {
                var details = await _journalEntryDetailService.GetByAccountAsync(dto);
                return Ok(details);
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
                return StatusCode(500, new { Error = "An error occurred while retrieving journal entry details", Details = ex.Message });
            }
        }
    }
}