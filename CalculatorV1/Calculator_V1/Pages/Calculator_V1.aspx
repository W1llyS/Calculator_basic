<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator_V1.aspx.cs" Inherits="Calculator_V1.Calculator_V1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator_V1</title>
    <link href="~/Pages/Styles/Site.css" rel="stylesheet" runat="server" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="calculator-container">
            <div class="input-section">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <div class="checkbox-container" style="width: 261px; height: 39px">
                    <asp:CheckBox ID="CheckBoxWholeNumbers" runat="server" Font-Overline="False" TextAlign="Left" />&nbsp;Celá čísla</div>
            </div>
            <div class="result-section">
                Výsledek:<br/>
                <asp:TextBox ID="TextBoxResult" runat="server" TextMode="MultiLine" Rows="5" ReadOnly="True" Width="265px"></asp:TextBox>
            </div>
            <div class="auto-style1">
                Historie:<br/>
                <asp:TextBox ID="TextBoxHistory" runat="server" TextMode="MultiLine" Rows="5" ReadOnly="True" Height="158px" Width="265px"></asp:TextBox>
            </div>
            <div class="button-section">
                <asp:Button ID="ButtonAdd" runat="server" Text="+" OnClick="Button2_Click" CssClass="aspButton" />
                <asp:Button ID="ButtonSubtract" runat="server" Text="-" OnClick="Button3_Click" CssClass="aspButton" />
                <asp:Button ID="ButtonMultiply" runat="server" Text="*" OnClick="Button4_Click" CssClass="aspButton" />
                <asp:Button ID="ButtonDivide" runat="server" Text="/" OnClick="Button5_Click" CssClass="aspButton" />
            </div>
        </div>
    </form>
</body>
</html>






