﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="administerproducts.aspx.cs" Inherits="EhandelGrupp1.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function CreateProduct() {
            alert("Test");

            var name = $("#registerproductname").val();
            var desc = $("#registerproductdescription").val();
            var price = $("#registerproductprice").val();
            var stock = $("#registerproductstock").val();

            $.get("services/svc-createproduct.aspx?createproduct=1", {
                "name": name, "description":desc, "price": price,
                "stock": stock, "isHidden": 0
            })
            .done(function (data) {
                alert(data);
            })
            .fail(function (data) {
                alert(data);
            });
        }
    </script>


    <div class="container">
        <h2>Lägg upp en produkt</h2>
        <div class="form-group" id="register-productname">
            <label for="productname">Produktnamn:</label>
            <input type="text" class="form-control" id="registerproductname">
        </div>

        <div class="form-group" id="register-productdescription">
            <label for="productdescription">Produktbeskrivning:</label>
            <input type="text" class="form-control" id="registerproductdescription">
        </div>

        <%--OBS! Ska pris registreras ink eller ex moms?--%>
        <div class="form-group" id="register-productprice">
            <label for="productprice">Styckpris:</label>
            <input type="number" min="0" class="form-control" id="registerproductprice">
        </div>

        <div class="form-group" id="register-productstock">
            <label for="stock">Varulager(antal):</label>
            <input type="number" min="0" class="form-control" id="registerproductstock">
        </div>
        <button type="button" class="btn btn-default" onclick="CreateProduct()" id="register-product-button">Lägg upp produkt</button>
        <%--OBS! Behövs en kod som tar denna input - genererar ett nytt produktid och sparar i sql--%>



        <%--från sql-table dbo orders--%>



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
                <tbody>
                    <tr>
                        <td>orderID db</td>
                        <td>date db</td>
                        <td>status</td>
                        <td>länk modal med items i order</td>
                    </tr>
                    <tr>
                </tbody>
            </table>
        </div>


    </div>

</asp:Content>
