using API_1.DTOs.MessageTemplate;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageTemplatesController : ControllerBase
    {
        private readonly IMessageTemplateService _messageTemplateService;

        public MessageTemplatesController(IMessageTemplateService messageTemplateService)
        {
            _messageTemplateService = messageTemplateService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateMessageTemplateDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int templateId = await _messageTemplateService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = templateId },
                    new { TemplateID = templateId, Message = "Message template created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the message template", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMessageTemplateDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.TemplateID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _messageTemplateService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Message template not found" });

                return Ok(new { Message = "Message template updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the message template", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _messageTemplateService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Message template not found" });

                return Ok(new { Message = "Message template deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the message template", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var template = await _messageTemplateService.GetByIdAsync(id);

                if (template == null)
                    return NotFound(new { Error = "Message template not found" });

                return Ok(template);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the message template", Details = ex.Message });
            }
        }

        [HttpGet("by-code")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCode([FromQuery] GetTemplateByCodeDTO dto)
        {
            try
            {
                var template = await _messageTemplateService.GetByCodeAsync(dto);

                if (template == null)
                    return NotFound(new { Error = "Message template not found" });

                return Ok(template);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the message template", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMessageTemplatesDTO dto)
        {
            try
            {
                var templates = await _messageTemplateService.GetAllAsync(dto);
                return Ok(templates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving message templates", Details = ex.Message });
            }
        }

        [HttpPost("parse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ParseMessage([FromBody] ParseMessageTemplateDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var (parsedMessage, parsedSubject) = await _messageTemplateService.ParseMessageAsync(dto);

                return Ok(new { ParsedMessage = parsedMessage, ParsedSubject = parsedSubject });
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
                return StatusCode(500, new { Error = "An error occurred while parsing the message template", Details = ex.Message });
            }
        }
    }
}