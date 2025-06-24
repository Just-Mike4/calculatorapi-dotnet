namespace CalculatorApi.Models
{
    public class CalculatorResult
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public string Operation { get; set; } = string.Empty;
        public double Result { get; set; }
    }
}
