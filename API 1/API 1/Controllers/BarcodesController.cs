using API_1.DTOs.Barcode;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodesController : ControllerBase
    {

        private readonly IBarcodeService _barcodeService;

        public BarcodesController(IBarcodeService barcodeService)
        {
            _barcodeService = barcodeService;
        }

     
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBarcodeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int barcodeId = await _barcodeService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = barcodeId },
                    new { BarcodeID = barcodeId, Message = "Barcode created successfully" }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the barcode", Details = ex.Message });
            }
        }

    
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBarcodeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != dto.BarcodeID)
                    return BadRequest(new { Error = "ID mismatch" });

                bool result = await _barcodeService.UpdateAsync(dto);

                if (!result)
                    return NotFound(new { Error = "Barcode not found" });

                return Ok(new { Message = "Barcode updated successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while updating the barcode", Details = ex.Message });
            }
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _barcodeService.DeleteAsync(id);

                if (!result)
                    return NotFound(new { Error = "Barcode not found" });

                return Ok(new { Message = "Barcode deleted successfully" });
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
                return StatusCode(500, new { Error = "An error occurred while deleting the barcode", Details = ex.Message });
            }
        }

 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var barcode = await _barcodeService.GetByIdAsync(id);

                if (barcode == null)
                    return NotFound(new { Error = "Barcode not found" });

                return Ok(barcode);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the barcode", Details = ex.Message });
            }
        }

 
        [HttpGet("by-product/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            try
            {
                var barcodes = await _barcodeService.GetByProductAsync(productId);
                return Ok(barcodes);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving barcodes", Details = ex.Message });
            }
        }

 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var barcodes = await _barcodeService.GetAllAsync();
                return Ok(barcodes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving barcodes", Details = ex.Message });
            }
        }


        [HttpGet("scan/{barcodeValue}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductByBarcode(string barcodeValue)
        {
            try
            {
                var barcode = await _barcodeService.GetProductByBarcodeAsync(barcodeValue);

                if (barcode == null)
                    return NotFound(new { Error = "Product not found for this barcode" });

                return Ok(barcode);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while scanning the barcode", Details = ex.Message });
            }
        }
    }
}
