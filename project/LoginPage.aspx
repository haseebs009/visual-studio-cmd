<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="project.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div style="max-width: 400px;">
    <h2 class="form-signin-heading">
        Login</h2>
    <label for="txtUsername">
        Username</label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Username"
        required />
    <br />
    <label for="txtPassword">
        Password</label>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="form-control"
        placeholder="Enter Password" required />
    <br />
    <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="Button1_Click" Class="btn btn-primary" />
    <br />
    <br />
    <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
        <p id="alert" runat="server" ></p> 
    </div>
</div>
</form>
</body>
</html>
