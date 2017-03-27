<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="EhandelGrupp1.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" id="profilePage">

         <%--från sql-table dbo customer--%>
        <div class="well well-sm">
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
            <div class="form-group">
                <label for="street">Gata:</label>
                <input type="text" class="form-control" value="street db" id="editstreet">
            </div>
            <div class="form-group">
                <label for="zip">Postnummer:</label>
                <input type="text" class="form-control" value="zip db" id="editzip">
            </div>
            <div class="form-group">
                <label for="city">Stad:</label>
                <input type="text" class="form-control" value="city db" id="editcity">
            </div>
            <div class="form-group">
                <label for="country">Land:</label>
                <input type="text" class="form-control" value="country db" id="editcountry">
            </div>
            <button type="submit" class="btn btn-info btn-xs">Uppdatera användare</button>
        </div>

       
        <div class="well well-sm">
            <div class="form-group">
                <label for="password">Nuvarande lösenord:</label>
                <input type="password" value="*********" class="form-control" id="currentpassword">
            </div>
            <div class="form-group">
                <label for="password">Nytt lösenord:</label>
                <input type="password" value="*********" class="form-control" id="newpassword">
            </div>
            <button type="submit" class="btn btn-info btn-xs">Uppdatera lösenord</button>
        </div>

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
