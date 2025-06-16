using System;

namespace Calculator_V1.BusinessLogic
{
    public class ComputeService
    {
        
        // Runs just the arithmetic. Throws on divide-by-zero or unsupported op.
       
        public double Compute(double a, double b, string operation)
        {
            switch (operation)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/":
                    if (b == 0)
                        throw new DivideByZeroException("Cannot divide by 0");
                    return a / b;
                default:
                    throw new InvalidOperationException("Unsupported operation");
            }
        }
    }
}
