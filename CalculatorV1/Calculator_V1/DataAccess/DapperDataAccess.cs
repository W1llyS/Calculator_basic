using Calculator_V1.Models;
using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Calculator_V1.DataAccess
{
    public class DapperDataAccess : IDataAccess
    {
        private readonly string _cs =
            ConfigurationManager
                .ConnectionStrings["SachyDb"]
                .ConnectionString;

        public IEnumerable<Calculation> LoadHistory(int top)
        {
            const string sql = @"
              SELECT TOP (@Top) Num1, Num2, Operation, Result
              FROM V1Calculation
              ORDER BY Id DESC";

            try
            {
               
                using (var conn = new SqlConnection(_cs))
                {
                    return conn.Query<Calculation>(sql, new { Top = top });
                }
       
            }
            catch (Exception ex)
            {
                Log.Error(ex, "LoadHistory failed");
                return new List<Calculation>();
            }
        }

        public void InsertCalculation(Calculation calc)
        {
            const string sql = @"
              INSERT INTO V1Calculation (Num1, Num2, Operation, Result)
              VALUES (@Num1, @Num2, @Operation, @Result)";

            try
            {
                using (var conn = new SqlConnection(_cs))
                {
                    conn.Execute(sql, calc);
                }
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, "InsertCalculation failed for {@Calc}", calc);
            }
        }

        public void DeleteOldRecords(int keepTop)
        {
            const string sql = @"
              DELETE FROM V1Calculation
              WHERE Id NOT IN (
                SELECT TOP (@KeepTop) Id
                FROM V1Calculation
                ORDER BY Id DESC
              )";

            try
            {
                using (var conn = new SqlConnection(_cs))
                {
                    conn.Execute(sql, new { KeepTop = keepTop });
                }
                
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, "DeleteOldRecords failed for keepTop={KeepTop}", keepTop);
            }
        }
    }
}
