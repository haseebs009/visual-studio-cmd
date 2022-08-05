<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="WebApplication4.Loginpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="login.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
         
<div style="max-width: 400px;">
    <h2 class="form-signin-heading">
        Login Page</h2>
    <label for="txtUsername">
        Email</label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Username"
        required="required"/>
    <br />
    <label for="txtPassword">
        Password</label>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="form-control"
        placeholder="Enter Password" required="required" />
    <br />
    <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="Button1_Click" Class="btn btn-primary" />
    <br />
    <br />
    <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
        
    </div>
</div>
        <div>
                   <p id="alert" runat="server"> </p> 

        </div>
</form>


</body>
</html>
