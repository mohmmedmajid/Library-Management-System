using Microsoft.AspNetCore.Mvc;
using API_1.DTOs.AccountBalance;
using API_1.Services.Interfaces;

namespace API_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountBalancesController : ControllerBase
    {
        private readonly IAccountBalanceService _accountBalanceService;

        public AccountBalancesController(IAccountBalanceService accountBalanceService)
        {
            _accountBalanceService = accountBalanceService;
        }


        [HttpGet("balance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBalance([FromQuery] GetAccountBalanceDTO dto)
        {
            try
            {
                var balance = await _accountBalanceService.GetBalanceAsync(dto);

                if (balance == null)
                    return NotFound(new { Error = "Account balance not found for the specified period" });

                return Ok(balance);
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
                return StatusCode(500, new { Error = "An error occurred while retrieving account balance", Details = ex.Message });
            }
        }


        [HttpGet("by-period")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByPeriod([FromQuery] GetBalancesByPeriodDTO dto)
        {
            try
            {
                var balances = await _accountBalanceService.GetByPeriodAsync(dto);
                return Ok(balances);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving account balances", Details = ex.Message });
            }
        }


        [HttpGet("year-to-date")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetYearToDate([FromQuery] GetYearToDateDTO dto)
        {
            try
            {
                var balances = await _accountBalanceService.GetYearToDateAsync(dto);
                return Ok(balances);
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
                return StatusCode(500, new { Error = "An error occurred while retrieving year-to-date balances", Details = ex.Message });
            }
        }
    }
}