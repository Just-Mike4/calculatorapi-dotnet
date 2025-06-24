using Microsoft.AspNetCore.Mvc;
using CalculatorApi.Models;
using CalculatorApi.Services;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] CalculatorRequest request)
        {
            try
            {
                var result = _calculatorService.Calculate(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
