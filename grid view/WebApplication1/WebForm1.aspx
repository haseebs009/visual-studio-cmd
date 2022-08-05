<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridEmployees" runat="server" AutoGenerateColumns="false" ShowFooter="true" AllowPaging="true" OnSelectedIndexChanged="gridEmployees_SelectedIndexChanged"
    OnPageIndexChanging="OnPageIndexChanging" OnRowEditing="OnRowEditing" OnRowCancelingEdit="canceledit" PageSize="15" OnRowDeleting="OnDelete"
                BackColor="White" BorderColor="#999999" BorderStyle="None" OnRowUpdating="gridEmployees_RowUpdating" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
                <Columns>
                    <asp:TemplateField HeaderText="Employee ID"> 
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("empId") %>'  runat="server" />           
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="emplID" Text='<%#Eval("empId") %>'  runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                              <asp:TextBox ID="emplIDfooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee Name"> 
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("name") %>'  runat="server" />           
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="emplname" Text='<%#Eval("name") %>'  runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                              <asp:TextBox ID="emplnamefooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Role"> 
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("role") %>'  runat="server" />           
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="emplrole" Text='<%#Eval("role") %>'  runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                              <asp:TextBox ID="emplrolefooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
      <asp:CommandField  ButtonType ="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblsuccessmessage" Text="" runat="server" Forecolor="Green"/>
            <br />
            <asp:Label ID="lblerrormessage" Text="" runat="server" Forecolor="red"/>
        </div>
    </form>
</body>
</html>
            