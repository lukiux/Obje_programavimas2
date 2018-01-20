<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ld1.aspx.cs" Inherits="Ld1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Skaičių magija</title>
    <style type="text/css">
        .newStyle1 {
        text-align: center;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <asp:Label ID="Label1" runat="server" Text="Skaičių magija" Font-Bold="True" Font-Names="Times New Roman" Font-Size="XX-Large" ForeColor="#3399FF" CssClass="newStyle1"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#6699FF" Text="Rezultatai"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Skaičiai"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Galutinio tikslas" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="172px" TextMode="MultiLine" Width="257px" Font-Size="X-Large" ForeColor="#336699" Enabled="False" EnableTheming="True"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Skaičiuoti!" OnClick="Button1_Click" BackColor="#6699FF" BorderStyle="Dashed" Font-Size="X-Large" ForeColor="Black" />
    
    </div>
    </form>
</body>
</html>
