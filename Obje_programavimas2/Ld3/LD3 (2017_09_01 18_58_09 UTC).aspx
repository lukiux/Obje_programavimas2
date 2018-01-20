<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LD3.aspx.cs" Inherits="LD3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LD3</title>
    <style type="text/css">
        html, body 
        {
            background-image: url('7018311-3d-black-background.jpg');
        }
        .newTable1 {
            height: 25%;
            width: 38%;
        }
        .newTable2 {
            height: 30%;
            width: 60%;
        }
        .newButton1 {
            height:5%; 
            width: 7%; 
            position: absolute;
        }
        #form1 {
            height: 722px;
            width: 1610px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Grandų mūšis" Style="left: 39%; position: absolute; top: 15px; width: 201px;" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" ></asp:Label>
        <asp:Label ID="Label2" runat="server" Style="top: 10%; position: absolute;" Text="Pradiniai duomenys U13a.txt:" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>        
        <asp:TextBox ID="TextBox1" runat="server" Style="top: 15%; position: absolute;" CssClass="newTable1" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Style="top: 15%; left: 55%; position: absolute;" CssClass="newTable1" TextMode="MultiLine"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Style="top: 10%; left: 55%; position: absolute;" Text="Pradiniai duomenys U13b.txt:" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>
        <asp:Button ID="Button1" runat="server"  Style="top: 24%; left: 43%;" Text="Spausdinti" OnClick="Button1_Click" CssClass="newButton1"/>
        <asp:Label ID="Label4" runat="server" Style="top: 45%; left: 20%; position: absolute;" Text="Rezultatai:" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Style="top: 50%; left: 20%; position: absolute;" TextMode="MultiLine" CssClass="newTable2" Enabled="False"></asp:TextBox>        
        <asp:TextBox ID="TextBox4" runat="server" Style="top: 89%; left: 40%; height: 30px; width: 200px; position: absolute;"></asp:TextBox>
        
        
        <asp:Label ID="Label5" runat="server" Style="top: 85%; left: 29%; position: absolute" Text="Įveskite žodžius, bet kuris pašalintas komandos žaidėjai" Font-Bold="True" ForeColor="White" Font-Size="X-Large"></asp:Label>
        <asp:Button ID="Button2" runat="server" Style="top: 95%; left: 42%; position:absolute;" Text="OK" CssClass="newButton1" OnClick="Button2_Click"/>
        
        
    </div>
    </form>
</body>
</html>
