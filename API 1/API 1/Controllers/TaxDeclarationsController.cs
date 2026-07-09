using API_1.DTOs.TaxDeclaration;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxDeclarationsController : ControllerBase
    {
        private readonly ITaxDeclarationService _taxDeclarationService;

        public TaxDeclarationsController(ITaxDeclarationService taxDeclarationService)
        {
            _taxDeclarationService = taxDeclarationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTaxDeclarationDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int declarationId = await _taxDeclarationService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = declarationId },
                    new { DeclarationID = declarationId, Message = "Tax declaration created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the tax declaration", Details = ex.Message });
            }
        }

        [HttpPut("{id}/submit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Submit(int id, [FromBody] SubmitTaxDeclarationDTO dto)
        {
            try
            {
                if (id != dto.DeclarationID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _taxDeclarationService.SubmitAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Tax declaration not found" });

                return Ok(new { Message = "Tax declaration submitted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while submitting the tax declaration", Details = ex.Message });
            }
        }

        [HttpPut("{id}/pay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> MarkAsPaid(int id, [FromBody] PayTaxDeclarationDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.DeclarationID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _taxDeclarationService.MarkAsPaidAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Tax declaration not found" });

                return Ok(new { Message = "Tax declaration marked as paid successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while marking the tax declaration as paid", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var declaration = await _taxDeclarationService.GetByIdAsync(id);

                if (declaration == null)
                    return NotFound(new { Error = "Tax declaration not found" });

                return Ok(declaration);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the tax declaration", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTaxDeclarationsDTO dto)
        {
            try
            {
                var declarations = await _taxDeclarationService.GetAllAsync(dto);
                return Ok(declarations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving tax declarations", Details = ex.Message });
            }
        }
    }
}
