<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page2aspx.aspx.cs" Inherits="second1.page2aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous"/>

    <script src="https://code.jquery.com/jquery-3.6.0.slim.min.js" integrity="sha256-u7e5khyithlIdTpu22PHhENmPcRdFiHRjhAuHcs05RI=" crossorigin="anonymous"></script>
    <link href="jquery.min.js" rel="stylesheet" />
 <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.12.1/css/jquery.dataTables.css"/>
    <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
    
    <script>
        $(document).ready(function () {
            $.ajax({
                url: 'http://localhost/secondbackend/list',
                method: 'GET',
                datatype: 'json',
                contentType: 'application/json',
                async: false,
                success: function (data) {
                    $('#table_id').dataTable({
                        data: data,
                        columns: [
                            { 'data': 'Name' },
                            { 'data': 'StudentNumber' },
                            { 'data': 'Address' }

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
                    <th>Name</th>
                    <th>Student Number</th>
                    <th>Address</th>
                </tr>
            </thead>
            <tbody>
                
            </tbody>
        </table>
    </form>
    </body>
</html>