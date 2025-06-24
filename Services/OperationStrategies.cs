namespace CalculatorApi.Services
{
    public interface IOperationStrategy
    {
        double Calculate(double operand1, double operand2);
        string OperationName { get; }
    }

    public class AddOperation : IOperationStrategy
    {
        public string OperationName => "add";
        public double Calculate(double operand1, double operand2) => operand1 + operand2;
    }

    public class SubtractOperation : IOperationStrategy
    {
        public string OperationName => "subtract";
        public double Calculate(double operand1, double operand2) => operand1 - operand2;
    }

    public class MultiplyOperation : IOperationStrategy
    {
        public string OperationName => "multiply";
        public double Calculate(double operand1, double operand2) => operand1 * operand2;
    }
}
