using CalculatorApi.Models;

namespace CalculatorApi.Services
{
    public interface ICalculatorService
    {
        CalculatorResult Calculate(double operand1, double operand2, string operation);
    }

    public class CalculatorService : ICalculatorService
    {
        private readonly IEnumerable<IOperationStrategy> _strategies;

        public CalculatorService(IEnumerable<IOperationStrategy> strategies)
        {
            _strategies = strategies;
        }

        public CalculatorResult Calculate(double operand1, double operand2, string operation)
        {
            var strategy = _strategies.FirstOrDefault(s =>
                s.OperationName.Equals(operation, StringComparison.OrdinalIgnoreCase));

            if (strategy == null)
                throw new ArgumentException("Unsupported operation. Use add, subtract, or multiply.");

            var result = strategy.Calculate(operand1, operand2);

            return new CalculatorResult
            {
                Operand1 = operand1,
                Operand2 = operand2,
                Operation = operation,
                Result = result
            };
        }
    }
}
