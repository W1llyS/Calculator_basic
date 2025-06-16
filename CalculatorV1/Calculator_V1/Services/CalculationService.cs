using System.Collections.Generic;
using Calculator_V1.DataAccess;
using Calculator_V1.Models;

namespace Calculator_V1.BusinessLogic
{
    public class CalculationService
    {
        private const int RetainHistory = 20;
        private readonly IDataAccess _dataAccess;
        private readonly ComputeService _engine;

        public CalculationService(IDataAccess dataAccess, ComputeService engine)
        {
            _dataAccess = dataAccess;
            _engine = engine;
        }

        public Calculation Calculate(double num1, double num2, string operation, bool roundResult)
        {
            // do the raw math
            double result = _engine.Compute(num1, num2, operation);

            // optional rounding
            if (roundResult)
                result = System.Math.Round(result);

            // create model
            var calc = new Calculation
            {
                Num1 = num1,
                Num2 = num2,
                Operation = operation,
                Result = result
            };

            
            _dataAccess.InsertCalculation(calc);
            _dataAccess.DeleteOldRecords(RetainHistory);

            return calc;
        }

        public IEnumerable<Calculation> GetHistory(int top = 10)
            => _dataAccess.LoadHistory(top);
    }
}
