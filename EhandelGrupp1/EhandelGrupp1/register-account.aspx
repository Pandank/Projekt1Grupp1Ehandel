<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="register-account.aspx.cs" Inherits="EhandelGrupp1.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <h2>Registrera kundkonto</h2>
        <div class="form-group" id="register-firstname">
            <label for="firstname">Förnamn:</label>
            <input type="text" class="form-control" id="registerfirstname">
        </div>
        <div class="form-group" id="register-lastname">
            <label for="lastname">Efternamn:</label>
            <input type="text" class="form-control" id="registerlastname">
        </div>
        <div class="form-group" id="register-email">
            <label for="email">E-post:</label>
            <input type="email" class="form-control" id="registeremail">
        </div>
         <div class="form-group" id="register-password">
            <label for="password">Lösenord:</label>
            <input type="password" class="form-control" id="registerpassword">
        </div>
         <div class="form-group" id="register-passwordCheck">
            <label for="password">Upprepa lösenord:</label>
            <input type="password" class="form-control" id="verifyregisterpassword">
        </div>     
        <h3>Adress</h3>   
        <div class="form-group" id="register-street">
            <label for="street">Gatuadress:</label>
            <input type="text" class="form-control" id="registerstreet">
        </div>
         <div class="form-group" id="register-zip">
            <label for="zip">Postnummer:</label>
            <input type="text" class="form-control" id="registerzip">
        </div>
         <div class="form-group" id="register-city">
            <label for="city">Stad:</label>
            <input type="text" class="form-control" id="registercity">
        </div>
        <div class="form-group" id="register-country">
            <label for="country">Land:</label>
            <input type="text" class="form-control" id="registercountry">
        </div>        
        <button type="button" class="btn btn-default" id="register-user-button">Registrera</button>
    </div>

</asp:Content>
