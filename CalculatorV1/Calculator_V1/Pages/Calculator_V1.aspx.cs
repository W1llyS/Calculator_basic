using System;
using System.Linq;
using Calculator_V1.BusinessLogic;
using Calculator_V1.DataAccess;
using Calculator_V1.Models;


namespace Calculator_V1
{
    public partial class Calculator_V1 : System.Web.UI.Page
    {
        private CalculationService _service;

        

        protected void Page_Init(object sender, EventArgs e)
        {
            var dal = new DapperDataAccess();         // IDataAccess impl
            var engine = new ComputeService();        // the raw-math class
            _service = new CalculationService(dal, engine);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                TextBoxHistory.Text = FormatHistory(_service.GetHistory(10));
        }

        private void DoCalculate(string operation)
        {
            try
            {
                double num1 = double.Parse(TextBox1.Text);
                double num2 = double.Parse(TextBox2.Text);
                bool round = CheckBoxWholeNumbers.Checked;

                // single call into service — no direct DataAccess 
                var calc = _service.Calculate(num1, num2, operation, round);

                TextBoxResult.Text = $"{calc.Num1} {calc.Operation} {calc.Num2} = {calc.Result}\r\n";
                TextBoxHistory.Text = FormatHistory(_service.GetHistory(10));
            }
            catch (Exception ex)
            {
                // display and log
                TextBoxResult.Text = $"Error: {ex.Message}\r\n";
               // Logger.Log(ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e) => DoCalculate("+");
        protected void Button3_Click(object sender, EventArgs e) => DoCalculate("-");
        protected void Button4_Click(object sender, EventArgs e) => DoCalculate("*");
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == "0")
            {
                TextBoxResult.Text = "Error: Cannot divide by zero.\r\n";
               
            }
            else
            {
                DoCalculate("/");
            }
        }

        private string FormatHistory(System.Collections.Generic.IEnumerable<Calculation> history)
        {
            return string.Join(
                Environment.NewLine,
                history.Select(c => $"{c.Num1} {c.Operation} {c.Num2} = {c.Result}")
            ) + Environment.NewLine;
        }
    }
}
