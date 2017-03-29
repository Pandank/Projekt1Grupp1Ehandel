<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="EhandelGrupp1.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" id="profilePage">
        <h2 class="h2">Dina kontouppgifter</h2>

         <%--från sql-table dbo customer--%>
        <div class="well well-sm">
            <div class="form-group">
                <label for="firstname">Förnamn:</label>
                <input type="text" class="form-control" id="editfirstname">
            </div>
            <div class="form-group">
                <label for="lastname">Efternamn:</label>
                <input type="text" class="form-control" id="editlastname">
            </div>
            <div class="form-group">
                <label for="email">E-post:</label>
                <input type="email" class="form-control" id="editemail">
            </div>
            <div class="form-group">
                <label for="street">Gata:</label>
                <input type="text" class="form-control" id="editstreet">
            </div>
            <div class="form-group">
                <label for="zip">Postnummer:</label>
                <input type="text" class="form-control" id="editzip">
            </div>
            <div class="form-group">
                <label for="city">Stad:</label>
                <input type="text" class="form-control" id="editcity">
            </div>
            <div class="form-group">
                <label for="country">Land:</label>
                <input type="text" class="form-control" id="editcountry">
            </div>
            <button type="button" class="btn btn-info btn-xs" id="updateUser">Uppdatera</button>
        </div>

       
        <div class="well well-sm">
            <div class="form-group">
                <label for="password">Nuvarande lösenord:</label>
                <input type="password" class="form-control" id="currentpassword">
            </div>
            <div class="form-group">
                <label for="password">Nytt lösenord:</label>
                <input type="password" class="form-control" id="newpassword">
            </div>
            <button type="button" class="btn btn-info btn-xs" id="updatePassword">Uppdatera lösenord</button>
        </div>

        <%--från sql-table dbo orders--%>
        <div class="well well-sm">
            <table class="table" id="orderTable">
                <thead>
                    <tr>
                        <th>Ordernr</th>
                        <th>Datum</th>
                        <th>Status</th>
                        <th>Detaljer</th>
                    </tr>
                </thead>
                <tbody>

                </tbody>
            </table>
        </div>

    </div>

</asp:Content>
