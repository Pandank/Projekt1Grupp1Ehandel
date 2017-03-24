<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="register-account.aspx.cs" Inherits="EhandelGrupp1.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="form-group">
            <label for="firstname">Förnamn:</label>
            <input type="text" class="form-control" id="registerfirstname">
        </div>
        <div class="form-group">
            <label for="pwd">Efternamn:</label>
            <input type="password" class="form-control" id="pwd">
        </div>
        <div class="checkbox">
            <label>
                <input type="checkbox">
                Remember me</label>
        </div>
        <button type="submit" class="btn btn-default">Submit</button>
    </div>

</asp:Content>
