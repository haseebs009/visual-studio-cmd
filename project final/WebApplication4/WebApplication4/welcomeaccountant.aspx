<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcomeaccountant.aspx.cs" Inherits="WebApplication4.welcomeaccountant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 id="greet" runat="server"> </h1>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Customer List" Width="150px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Get Item List" Width="193px" />
    &nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Generate Bill" Width="141px" />
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Logout" Width="143px" />
    </form>
</body>
</html>
