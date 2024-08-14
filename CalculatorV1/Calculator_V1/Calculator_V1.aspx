<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator_V1.aspx.cs" Inherits="Calculator_V1.Calculator_V1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator_V1</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f5f5f5;
            margin: 40px;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }
        .calculator-container {
            width: 300px;
            background-color: #ffffff;
            padding: 20px;
            box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.2);
            border-radius: 20px;
        }
        .input-section, .result-section, .history-section, .button-section {
            margin-bottom: 15px;
        }
        .input-section input, .result-section input, .history-section textarea {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ddd;
        }
        .input-section .checkbox-container {
            display: flex;
            align-items: center;
            margin-top: 5px;
        }
        .auto-style1 {
            margin-bottom: 15px;
        }
        .button-section {
            display: flex;
            justify-content: space-between;
        }
        .button-section .aspButton {
            width: 48%;
            padding: 10px;
            font-size: 18px;
            cursor: pointer;
            border: 1px solid #333;
            background-color: #b3e0ff; /* světle modrá barva */
            color: #333;
            border-radius: 5px;
            transition: background-color 0.3s;
        }
        .button-section .aspButton:hover {
            background-color: #99c2ff;
        }
    </style>
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






