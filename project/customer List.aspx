<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customer List.aspx.cs" Inherits="project.customer_List" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <link href="jquery.min.js" rel="stylesheet" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#table_id').DataTable();
        });
    </script>
    <script>
        $(document).ready(function () {
            $.ajax({
                url: "customer List.aspx/Customerdata()",
                'method': 'GET',
                'contentType': 'application/json'
            }).done(function (data) {
                console.log('dataaa', data);
                $('#table_id').dataTable({
                    'aaData': data['data'],
                    "columns": [
                        { "data": "customerId", },
                        { "data": "Name", },
                                   }]
        })
        })
    </script>
    <title></title>
</head>
<body>




    <form id="form1" runat="server">




<%--    <script>
        $(document).ready(function () {

                $.ajax({
                    url: 'customer List.aspx/Customerdata',
                    method: 'post'
                   datatype: 'json',
                    contentType: 'application/json',
                    async: false,
                    success: function (data) {
                        $('#table_id').DataTable({
                            data: JSON.parse(data.d),
                            columns: [
                                { 'data': 'customerId' },
                                { 'data': 'Name' }

                            ]
                        })
                        
                        }
                    },

                });
            }  }
    </script>--%>


    <table id="table_id">
        <thead>
            <tr>
                <th>Sites</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>SitePoint</td>
            </tr>
            <tr>
                <td>Learnable</td>
            </tr>
            <tr>
                <td>Flippa</td>
            </tr>
        </tbody>
    </table>

      <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/jquery.dataTables.min.js"></script>
    <script>

</script>
    </form>
</body>
</html>
