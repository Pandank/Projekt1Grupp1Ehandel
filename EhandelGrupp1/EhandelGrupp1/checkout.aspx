<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="EhandelGrupp1.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" id="checkoutPage">
        <h2>Kassa</h2>
        <table class="table" id="checkoutTable">
            <thead>
                <tr>
                    <th>Produktnamn</th>
                    <th>Enhetspris</th>
                    <th>Antal</th>
                    <th>Pris</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>

        <h3>Leverans- och fakturaadress</h3>
        <div class="form-group">
            <label for="firstname">Förnamn:</label>
            <input type="text" class="form-control" id="customerfirstname">
        </div>
        <div class="form-group">
            <label for="lastname">Efternamn:</label>
            <input type="text" class="form-control" id="customerlastname">
        </div>
        <div class="form-group">
            <label for="email">E-post:</label>
            <input type="email" class="form-control" id="customeremail">
        </div>
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

        <button type="submit" class="btn btn-primary">Genomför köp</button>

    </div>

</asp:Content>
