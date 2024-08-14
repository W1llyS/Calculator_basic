using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator_V1
{
    public partial class Calculator_V1 : System.Web.UI.Page
    {
        private DataAccess dataAccess;

        protected void Page_Load(object sender, EventArgs e)
        {
            dataAccess = new DataAccess("workstation id=SachyDB.mssql.somee.com;packet size=4096;user id=sachyckyne_SQLLogin_1;pwd=ri31z9jhqv;data source=SachyDB.mssql.somee.com;persist security info=False;initial catalog=SachyDB;TrustServerCertificate=True");

            if (!IsPostBack)
            {
                TextBoxHistory.Text = dataAccess.LoadHistory();
            }
        }

        private void SendError(string errorMessage, TextBox targetTextBox)
        {
            targetTextBox.Text += $"Chyba: {errorMessage}\r\n";
            dataAccess.LogErrorToFile(errorMessage);
        }

        private void Calculate(string operation, Func<double, double, double> func)
        {
            try
            {
                double num1 = double.Parse(TextBox1.Text);
                double num2 = double.Parse(TextBox2.Text);
                double result = func(num1, num2);

                if (CheckBoxWholeNumbers.Checked)  // Rounds up to the closest whole number
                {
                    result = Math.Round(result);
                }

                TextBoxResult.Text = $"{num1} {operation} {num2} = {result}\r\n";

                dataAccess.InsertCalculation(num1, num2, operation, result);

                TextBoxHistory.Text = dataAccess.LoadHistory();
                dataAccess.DeleteOldRecords();
            }
            catch (Exception ex)
            {
                SendError(ex.Message, TextBoxResult);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calculate("+", (a, b) => a + b);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Calculate("-", (a, b) => a - b);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Calculate("*", (a, b) => a * b);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == "0")
            {
                SendError("Nelze dělit nulou", TextBoxResult); // Can't divide by 0
            }
            else
            {
                Calculate("/", (a, b) => a / b);
            }
        }
    }
}
