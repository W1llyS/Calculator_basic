using System.Collections.Generic;
using Calculator_V1.Models;

namespace Calculator_V1.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<Calculation> LoadHistory(int top);
        void InsertCalculation(Calculation calc);
        void DeleteOldRecords(int keepTop);
    }
}
