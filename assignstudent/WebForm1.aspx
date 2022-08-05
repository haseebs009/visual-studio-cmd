<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="assignstudent.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.min.js"> </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </div>
        <input type="button" id="Button1" onclick="return StudentdataJS();" value="Search" /><br />
        &nbsp;<div>
            <span> Name</span>
            <input type="text" id="name1" />
         <span> Marks</span>
            <input type="text" id="marks1" />
            <span> ID</span>
            <input type="text" id="id1" />
        </div>

    </form>
</body>
<script>
    function StudentdataJS() {
        var inputVal = document.getElementById("DropDownList1").value;
        if (inputVal == "") return;
        $.ajax({
            url: 'WebForm1.aspx/Studentdata',
            type: 'post',
            data: JSON.stringify({ "inputValue": inputVal }),
            contentType: 'application/json',
            async: false,
            success: function (data) {
                if (data.d) {
                    data1 = JSON.parse(data.d);
                    console.log(data1.toString);
                    $("#name1").val(data1['name']);
                    $("#id1").val(data1['id']);
                    $("#marks1").val(data1['marks']);
                }
            },


        });
    }
    </script>
</html>
