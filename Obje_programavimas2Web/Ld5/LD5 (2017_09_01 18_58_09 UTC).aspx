<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LD5.aspx.cs" Inherits="LD5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LD5</title>
    <style type="text/css">
        html, body 
        {
            background-image: url('7018311-3d-black-background.jpg');
        }
        .newTable1 {
            height: 25%;
            width: 32%;
        }
        .newTable2 {
            height: 30%;
            width: 60%;
        }
        .newButton1 {
            height:5%; 
            width: 11%; 
            position: absolute;
        }
        #form1 {
            height: 684px;
            width: 1610px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Telefonų abonentai" Style="left: 40%; position: absolute; top: 15px; width: 282px;" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" ></asp:Label>
        <asp:Label ID="Label2" runat="server" Style="top: 10%; position: absolute;" Text="Pradiniai duomenys U13.txt:" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>        
        <asp:TextBox ID="TextBox1" runat="server" Style="top: 15%; position: absolute; left: 10px;" CssClass="newTable1" TextMode="MultiLine"></asp:TextBox>       
        <asp:Button ID="Button1" runat="server"  Style="top: 25%; left: 42%; right: 802px;" Text="Spausdinti" OnClick="Button1_Click" CssClass="newButton1"/>        
        <asp:TextBox ID="TextBox2" runat="server" Style="top: 15%; left: 65%; position: absolute;" CssClass="newTable1" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" Style="top: 52%; left: 18%; position: absolute;" TextMode="MultiLine" CssClass="newTable2" Enabled="False"></asp:TextBox>  
        <asp:Label ID="Label4" runat="server" Style="top: 10%; left: 65%; position: absolute;" Text="Telefonų numerių sąrašas" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>
        <asp:Label ID="Label3" runat="server" Style="top: 45%; left: 18%; position: absolute;" Text="Rezultatai:" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>
    </div>
    </form>
</body>
</html>
