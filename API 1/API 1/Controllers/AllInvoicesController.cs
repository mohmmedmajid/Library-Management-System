using API_1.DTOs.AllInvoices;
using API_1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class AllInvoicesController : ControllerBase
    {
        private readonly IAllInvoicesService _allInvoicesService;

        public AllInvoicesController(IAllInvoicesService allInvoicesService)
        {
            _allInvoicesService = allInvoicesService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] string? invoiceType = null, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null, [FromQuery] int? customerId = null)
        {
            try
            {
                var dto = new GetAllInvoicesDTO
                {
                    InvoiceType = invoiceType,
                    StartDate = startDate,
                    EndDate = endDate,
                    CustomerID = customerId
                };

                var invoices = await _allInvoicesService.GetAllAsync(dto);
                return Ok(invoices);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
}