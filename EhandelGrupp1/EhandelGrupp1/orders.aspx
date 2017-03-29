<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="EhandelGrupp1.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(
            function () {
                $.get("services/svc-allorders.aspx").done(function (data) {
                    data = JSON.parse(data);

                    console.log(data);

                    for (var i = 0; i < data.length; i++) {
                        var date = data[i].date.substring(0, 16);
                        date = date.replace('T', ' ');

                        $("#allOrderBody").append("<tr><td>" + data[i].orderId + "</td><td>" + date + "</td><td>" + data[i].status + "</td><td><a href='#'>Läs mer</a></td></tr>");
                    }
                });

            });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="well well-sm">
            <table class="table">
                <thead>
                    <tr>
                        <th>Ordernr</th>
                        <th>Datum</th>
                        <th>Status</th>
                        <th>Detaljer</th>
                    </tr>
                </thead>
                <tbody id="allOrderBody">
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
