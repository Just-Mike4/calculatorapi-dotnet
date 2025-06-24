using CalculatorApi.Models;

namespace CalculatorApi.Services
{
    public class CalculatorService : ICalculatorService
    {
        public CalculatorResult Calculate(CalculatorRequest request)
        {
            double result = request.Operation.ToLower() switch
            {
                "add" => request.Operand1 + request.Operand2,
                "subtract" => request.Operand1 - request.Operand2,
                "multiply" => request.Operand1 * request.Operand2,
                _ => throw new ArgumentException("Unsupported operation. Use 'add', 'subtract', or 'multiply'.")
            };

            return new CalculatorResult
            {
                Operand1 = request.Operand1,
                Operand2 = request.Operand2,
                Operation = request.Operation,
                Result = result
            };
        }
    }
}
