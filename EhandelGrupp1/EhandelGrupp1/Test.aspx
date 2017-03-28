<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EhandelGrupp1.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function CreateCustomer()
        {
            alert("Test");

            $.get("services/svc-createcustomer.aspx?createCustomer=1", { "email": $("#email").val(), "firstname": $("#firstname").val(), "lastname": $("#lastname").val(),
                "isAdmin": $("#isAdmin").val(), "password": $("#password").val(), "street": $("#street").val(), "zip": $("#zip").val(), "city": $("#city").val(),
                "country": $("#country").val()})
            .done(function (data) {
                alert(data);
            });
        }
    </script>

    <input type="email" id="email" required />
    <input type="text" id="firstname" required />
    <input type="text" id="lastname" required />
    <input type="text" id="isAdmin" required />
    <input type="password" id="password" required />
    <input type="text" id="street" required />
    <input type="text" id="zip" required />
    <input type="text" id="city" required />
    <input type="text" id="country" required />



    <input type="button" id="createCustomer" onclick="CreateCustomer()" value="Click me" />
</asp:Content>

