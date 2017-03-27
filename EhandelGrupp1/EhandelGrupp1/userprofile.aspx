<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="EhandelGrupp1.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h2>Användarprofil</h2>
        <div class="form-group">
            <label for="firstname">Förnamn:</label>
            <input type="text" class="form-control" value="firstname db" id="editfirstname">
        </div>
        <div class="form-group">
            <label for="lastname">Efternamn:</label>
            <input type="text" class="form-control" value="lastname db" id="editlastname">
        </div>
        <div class="form-group">
            <label for="email">E-post:</label>
            <input type="email" class="form-control" value="email db" id="editemail">
        </div>
        <button type="submit" class="btn btn-primary btn-xs">Uppdatera användare</button>


        <div class="form-group">
            <label for="password">Nuvarande lösenord:</label>
            <input type="password" value="*********" class="form-control" id="currentpassword">
        </div>
        <div class="form-group">
            <label for="password">Nytt lösenord:</label>
            <input type="password" value="*********" class="form-control" id="newpassword">
        </div>
        <button type="submit" class="btn btn-primary btn-xs">Uppdatera lösenord</button>


        <h3>Leveransadress</h3>
        <div class="form-group">
            <label for="street">Gata:</label>
            <input type="text" class="form-control" id="registerstreet">
        </div>
        <div class="form-group">
            <label for="zip">Postnummer:</label>
            <input type="text" class="form-control" id="registerzip">
        </div>
        <div class="form-group">
            <label for="city">Stad:</label>
            <input type="text" class="form-control" id="registercity">
        </div>
        <div class="form-group">
            <label for="country">Land:</label>
            <input type="text" class="form-control" id="registercountry">
        </div>
        <button type="submit" class="btn btn-default">Registrera</button>
    </div>

</asp:Content>
