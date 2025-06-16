using System;

namespace Calculator_V1.Models
{
 
    public class Calculation
    {
        /// <summary>First operand.</summary>
        public double Num1 { get; set; }

        /// <summary>Second operand.</summary>
        public double Num2 { get; set; }

        /// <summary>The operation symbol, e.g. "+", "-", "*", "/"</summary>
        public string Operation { get; set; }

        /// <summary>The computed result.</summary>
        public double Result { get; set; }

     
    }
}
