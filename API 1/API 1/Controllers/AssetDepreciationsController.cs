using API_1.DTOs.AssetDepreciation;
using API_1.Services;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetDepreciationsController : ControllerBase
    {
        private readonly IAssetDepreciationService _depreciationService;

        public AssetDepreciationsController(IAssetDepreciationService depreciationService)
        {
            _depreciationService = depreciationService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateAssetDepreciationDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int depreciationId = await _depreciationService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = depreciationId },
                    new { DepreciationID = depreciationId, Message = "Asset depreciation created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the asset depreciation", Details = ex.Message });
            }
        }


        [HttpPut("{id}/post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(int id, [FromBody] PostAssetDepreciationDTO dto)
        {
            try
            {
                if (id != dto.DepreciationID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _depreciationService.PostAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Asset depreciation not found" });

                return Ok(new { Message = "Asset depreciation posted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while posting the asset depreciation", Details = ex.Message });
            }
        }


        [HttpPost("process-monthly")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ProcessMonthly([FromBody] ProcessMonthlyDepreciationDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool result = await _depreciationService.ProcessMonthlyAsync(dto);

                return Ok(new { Message = "Monthly depreciation processed successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while processing monthly depreciation", Details = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var depreciation = await _depreciationService.GetByIdAsync(id);

                if (depreciation == null)
                    return NotFound(new { Error = "Asset depreciation not found" });

                return Ok(depreciation);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the asset depreciation", Details = ex.Message });
            }
        }

        [HttpGet("by-asset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByAsset([FromQuery] GetDepreciationByAssetDTO dto)
        {
            try
            {
                var depreciations = await _depreciationService.GetByAssetAsync(dto);
                return Ok(depreciations);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving asset depreciations", Details = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDepreciationsDTO dto)
        {
            try
            {
                if (dto.Status == "All")
                    dto.Status = null;

                // Ignore invalid year/month values
                if (dto.FiscalYear.HasValue && dto.FiscalYear < 2000)
                    dto.FiscalYear = null;

                if (dto.FiscalMonth.HasValue && (dto.FiscalMonth < 1 || dto.FiscalMonth > 12))
                    dto.FiscalMonth = null;

                var depreciations = await _depreciationService.GetAllAsync(dto);
                return Ok(depreciations);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving asset depreciations", Details = ex.Message });
            }
        }


        [HttpGet("summary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSummary([FromQuery] GetDepreciationSummaryDTO dto)
        {
            try
            {
                var summary = await _depreciationService.GetSummaryAsync(dto);
                return Ok(summary);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving depreciation summary", Details = ex.Message });
            }
        }
    }
}