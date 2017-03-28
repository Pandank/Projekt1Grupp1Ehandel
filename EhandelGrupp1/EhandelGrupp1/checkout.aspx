<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="EhandelGrupp1.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h2>Orderöversikt</h2>
        <table class="table">
            <thead>
                <tr>
                    <th>Produktnamn</th>
                    <th>Enhetspris</th>
                    <th>Antal</th>
                    <th>Pris</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Multicopy, koperingspapper</td>
                    <td>40 kr</td>
                    <td>
                        <input type="number" value="1" id="itemCounter" /></td>
                    <td>jQuery pris ggr antal</td>
                </tr>
                <tr>
                    <td>Hålslag</td>
                    <td>50 kr</td>
                    <td>
                        <input type="number" value="1" id="itemCounter" /></td>
                    <td>jQuery pris ggr antal</td>
                </tr>
            </tbody>
        </table>

        <h3>Leverans- och fakturaadress</h3>
        <div class="form-group">
            <label for="street">Gata:</label>
            <input type="text" class="form-control" id="customerstreet">
        </div>
        <div class="form-group">
            <label for="zip">Postnummer:</label>
            <input type="text" class="form-control" id="customerzip">
        </div>
        <div class="form-group">
            <label for="city">Stad:</label>
            <input type="text" class="form-control" id="customercity">
        </div>
        <div class="form-group">
            <label for="country">Land:</label>
            <input type="text" class="form-control" id="customercountry">
        </div>

        <button type="button" class="btn btn-default" id="addAnotherAddress">Annan leveransadress</button>

        <div id="otherAddress">
            <h4>Annan leveransadress</h4>
            <div class="form-group">
                <label for="street">Gata:</label>
                <input type="text" class="form-control" id="tempstreet">
            </div>
            <div class="form-group">
                <label for="zip">Postnummer:</label>
                <input type="text" class="form-control" id="tempzip">
            </div>
            <div class="form-group">
                <label for="city">Stad:</label>
                <input type="text" class="form-control" id="tempcity">
            </div>
            <div class="form-group">
                <label for="country">Land:</label>
                <input type="text" class="form-control" id="tempcountry">
            </div>
        </div>

        <button type="submit" class="btn btn-default">Köp</button>

    </div>

</asp:Content>
