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

        [HttpGet]
        [ProducesResponseType(typeof(CalculatorResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public IActionResult Calculate(
            [FromQuery] double operand1,
            [FromQuery] double operand2,
            [FromQuery] string operation)
        {
            try
            {
                var result = _calculatorService.Calculate(operand1, operand2, operation);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
