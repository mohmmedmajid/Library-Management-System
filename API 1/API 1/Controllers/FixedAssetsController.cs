using API_1.DTOs.FixedAsset;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedAssetsController : ControllerBase
    {
        private readonly IFixedAssetService _fixedAssetService;

        public FixedAssetsController(IFixedAssetService fixedAssetService)
        {
            _fixedAssetService = fixedAssetService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateFixedAssetDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int assetId = await _fixedAssetService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = assetId },
                    new { AssetID = assetId, Message = "Fixed asset created successfully" }
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
                return StatusCode(500, new { Error = "An error occurred while creating the fixed asset", Details = ex.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateFixedAssetDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.AssetID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _fixedAssetService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Fixed asset not found" });

                return Ok(new { Message = "Fixed asset updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the fixed asset", Details = ex.Message });
            }
        }

        [HttpPut("{id}/dispose")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Dispose(int id, [FromBody] DisposeFixedAssetDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.AssetID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _fixedAssetService.DisposeAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Fixed asset not found" });

                return Ok(new { Message = "Fixed asset disposed successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while disposing the fixed asset", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var asset = await _fixedAssetService.GetByIdAsync(id);

                if (asset == null)
                    return NotFound(new { Error = "Fixed asset not found" });

                return Ok(asset);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the fixed asset", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFixedAssetsDTO dto)
        {
            try
            {
                var assets = await _fixedAssetService.GetAllAsync(dto);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving fixed assets", Details = ex.Message });
            }
        }

        [HttpGet("due-for-maintenance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDueForMaintenance()
        {
            try
            {
                var assets = await _fixedAssetService.GetDueForMaintenanceAsync();
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving assets due for maintenance", Details = ex.Message });
            }
        }

        [HttpGet("summary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSummary()
        {
            try
            {
                var summary = await _fixedAssetService.GetSummaryAsync();
                return Ok(summary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving fixed assets summary", Details = ex.Message });
            }
        }
    }
}