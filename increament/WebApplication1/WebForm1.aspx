<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" value="0"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Increament" OnClick="Button1_Click" />
            <p id="alert" runat="server"></p>
        </div>
    </form>
</body>
</html>
