﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcomepage.aspx.cs" Inherits="project.welcomepage" %>

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
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="See Customer List" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="See Item List" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="See Employee List" />
    </form>
</body>
</html>
