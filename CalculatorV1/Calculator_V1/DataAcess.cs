using System;
using System.Data.SqlClient;
using System.IO;

public class DataAccess
{
    private string conString;

    public DataAccess(string connectionString)
    {
        this.conString = connectionString;
    }

    public void LogErrorToFile(string errorMessage)
    {
        try
        {
            string path = @"C:\Users\kolko\Desktop\Git Calculator repository\Calculator_V1-ErrorLog--DatabaseFix--Unit\Errors.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"[{DateTime.Now}] {errorMessage}");
            }
        }
        catch
        {

        }
    }

    public string LoadHistory()
    {
        string history = string.Empty;
        try
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string sql = "SELECT TOP 10 Num1, Num2, Operation, Result FROM V1Calculation ORDER BY Id DESC";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double num1 = (double)reader["Num1"];
                            double num2 = (double)reader["Num2"];
                            string operation = reader["Operation"].ToString();
                            double result = (double)reader["Result"];
                            history += $"{num1} {operation} {num2} = {result}\r\n";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            history += $"Chyba při načítání historie: {ex.Message}\r\n";
            LogErrorToFile($"Chyba při načítání historie: {ex.Message}");
        }
        return history;
    }

    public void DeleteOldRecords()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string sql = "DELETE FROM V1Calculation WHERE Id NOT IN (SELECT TOP 20 Id FROM V1Calculation ORDER BY Id DESC)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        } //
        catch (Exception ex)
        {
            LogErrorToFile($"Chyba při mazání starých záznamů: {ex.Message}");
        }
    }

    public void InsertCalculation(double num1, double num2, string operation, double result)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string sql = "INSERT INTO V1Calculation (Num1, Num2, Operation, Result) VALUES (@num1, @num2, @operation, @result)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@num1", num1);
                    cmd.Parameters.AddWithValue("@num2", num2);
                    cmd.Parameters.AddWithValue("@operation", operation);
                    cmd.Parameters.AddWithValue("@result", result);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorToFile(ex.Message);
        }
    }
}
