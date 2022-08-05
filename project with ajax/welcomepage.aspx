<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcomepage.aspx.cs" Inherits="project.welcomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 id="greet" runat="server"> </h1>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Customer List" Width="150px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Get Employee List" Width="185px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Get Item List" Width="193px" />
    </form>
</body>
</html>
