<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Calculator_V1.aspx.cs"
    Inherits="Calculator_V1.Calculator_V1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Modern Calculator</title>
  <link href="~/Pages/Styles/Site.css" rel="stylesheet" runat="server" />
</head>
<body>
  <form id="form1" runat="server">
    <div class="calculator-container">

      <div class="input-section">
        <label for="TextBox1">First number</label>
        <asp:TextBox ID="TextBox1"
                     runat="server"
                     CssClass="input-field" />

        <label for="TextBox2">Second number</label>
        <asp:TextBox ID="TextBox2"
                     runat="server"
                     CssClass="input-field" />

        <div class="checkbox-container">
          <asp:CheckBox ID="CheckBoxWholeNumbers"
                        runat="server"
                        Text="Use whole numbers." />
        </div>
      </div>

      <div class="result-section">
        <label for="TextBoxResult">Results</label>
        <asp:TextBox ID="TextBoxResult"
                     runat="server"
                     TextMode="MultiLine"
                     Rows="3"
                     ReadOnly="True"
                     CssClass="input-field" />
      </div>

      <div class="history-section">
        <label for="TextBoxHistory">History: </label>
        <asp:TextBox ID="TextBoxHistory"
                     runat="server"
                     TextMode="MultiLine"
                     Rows="5"
                     ReadOnly="True"
                     CssClass="input-field" />
      </div>

      <div class="button-section">
        <asp:Button ID="ButtonAdd"
                    runat="server"
                    Text="+"
                    OnClick="Button2_Click"
                    CssClass="aspButton" />

        <asp:Button ID="ButtonSubtract"
                    runat="server"
                    Text="–"
                    OnClick="Button3_Click"
                    CssClass="aspButton" />

        <asp:Button ID="ButtonMultiply"
                    runat="server"
                    Text="×"
                    OnClick="Button4_Click"
                    CssClass="aspButton" />

        <asp:Button ID="ButtonDivide"
                    runat="server"
                    Text="÷"
                    OnClick="Button5_Click"
                    CssClass="aspButton" />
      </div>

    </div>
  </form>
</body>
</html>
