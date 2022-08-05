<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerList.aspx.cs" Inherits="project.customer_List" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.slim.min.js" integrity="sha256-u7e5khyithlIdTpu22PHhENmPcRdFiHRjhAuHcs05RI=" crossorigin="anonymous"></script>
    <link href="jquery.min.js" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css" />
    <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>


    <script>
        $(document).ready(function () {
            $.ajax({
                url: 'customerList.aspx/Customerdata',
                method: 'POST',
                datatype: 'json',
                contentType: 'application/json',
                async: false,
                success: function (data) {

                    $('#table_id').dataTable({

                        data: JSON.parse(data.d),

                        columns: [

                            { 'data': 'customerId' },
                            { 'data': 'Name' }

                        ]
                    });
                }
            });
        });
    </script>
    <title></title>
</head>
<body>




    <form id="form1" runat="server">

        <table id="table_id">
            <thead>
                <tr>
                    <th>ID AJAA</th>
                    <th>NAME AJAA</th>
                </tr>
            </thead>
            <tbody>
                
            </tbody>
        </table>
        

    </form>
</body>
</html>
