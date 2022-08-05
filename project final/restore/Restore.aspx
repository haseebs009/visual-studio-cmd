<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="restore.Restore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div">
            <h1>Restore values</h1>
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
&nbsp;      <asp:Button ID="Button2" runat="server" Text="Restore Using Hidden Field" OnClick="Button2_Click" />
&nbsp;      <asp:Button ID="Button3" runat="server" Text="Restore Using View State" OnClick="Button3_Click" />
&nbsp;      <p id="alert" runat="server"></p>
            <asp:HiddenField ID="hiddenfield1" runat="server" value=""/>
            <asp:HiddenField ID="hiddenfield2" runat="server" value=""/>

        </div>
    </form>
</body>
</html>
