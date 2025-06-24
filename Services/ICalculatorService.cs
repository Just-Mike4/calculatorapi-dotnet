using CalculatorApi.Models;

namespace CalculatorApi.Services
{
    public interface ICalculatorService
    {
        CalculatorResult Calculate(CalculatorRequest request);
    }
}
