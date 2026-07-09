using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.JournalEntry;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalEntriesController : ControllerBase
    {
        private readonly IJournalEntryService _journalEntryService;

        public JournalEntriesController(IJournalEntryService journalEntryService)
        {
            _journalEntryService = journalEntryService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateJournalEntryDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int journalEntryId = await _journalEntryService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = journalEntryId },
                    new { JournalEntryID = journalEntryId, Message = "Journal entry created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the journal entry", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJournalEntryDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.JournalEntryID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _journalEntryService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Journal entry not found" });

                return Ok(new { Message = "Journal entry updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the journal entry", Details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _journalEntryService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Journal entry not found" });

                return Ok(new { Message = "Journal entry deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the journal entry", Details = ex.Message });
            }
        }


        [HttpPost("{id}/post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(int id, [FromBody] PostJournalEntryDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.JournalEntryID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _journalEntryService.PostAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Journal entry not found" });

                return Ok(new { Message = "Journal entry posted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while posting the journal entry", Details = ex.Message });
            }
        }


        [HttpPost("{id}/reverse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Reverse(int id, [FromBody] ReverseJournalEntryDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.JournalEntryID)
                    return BadRequest(new { Error = "ID mismatch" });

                int reversalEntryId = await _journalEntryService.ReverseAsync(dto);

                return Ok(new { ReversalEntryID = reversalEntryId, Message = "Journal entry reversed successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while reversing the journal entry", Details = ex.Message });
            }
        }

 
        [HttpGet("generate-number")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GenerateNumber()
        {
            try
            {
                string number = await _journalEntryService.GenerateNumberAsync();
                return Ok(new { JournalEntryNumber = number });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while generating journal entry number", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var journalEntry = await _journalEntryService.GetByIdAsync(id);

                if (journalEntry == null)
                    return NotFound(new { Error = "Journal entry not found" });

                return Ok(journalEntry);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the journal entry", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllJournalEntriesDTO dto)
        {
            try
            {
                var journalEntries = await _journalEntryService.GetAllAsync(dto);
                return Ok(journalEntries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving journal entries", Details = ex.Message });
            }
        }


        [HttpGet("by-reference")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByReference([FromQuery] string referenceType, [FromQuery] int referenceId)
        {
            try
            {
                var journalEntries = await _journalEntryService.GetByReferenceAsync(referenceType, referenceId);
                return Ok(journalEntries);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving journal entries", Details = ex.Message });
            }
        }
    }
}