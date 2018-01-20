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
        <br />
        <asp:Label ID="Label6" runat="server" Font-Names="Tahoma" Font-Size="Medium" Text="pasirinkite 6 skaičius:"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Size="Large">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Font-Size="Large">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Font-Size="Large">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" Font-Size="Large">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" Font-Size="Large">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" Font-Size="Large">
            <asp:ListItem Value="25"></asp:ListItem>
            <asp:ListItem Value="50"></asp:ListItem>
            <asp:ListItem Value="75"></asp:ListItem>
            <asp:ListItem Value="100"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Font-Names="Tahoma" Font-Size="Medium" Text="įrašykite galutinį skaičių nuo 100 iki 999:"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" Font-Size="X-Large" OnTextChanged="TextBox2_TextChanged" ValidateRequestMode="Enabled" Width="41px">100</asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Skaičiuoti!" OnClick="Button1_Click" BackColor="#6699FF" BorderStyle="Dashed" Font-Size="X-Large" ForeColor="Black" />
    
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#6699FF" Text="Label"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="172px" TextMode="MultiLine" Width="257px" Font-Size="X-Large" ForeColor="#336699" Enabled="False" EnableTheming="True"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
