<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="EhandelGrupp1.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="1">
            <h2 class="h2">PRODUKTNAMN</h2>
            <img src="img/Papper.jpg" alt="" class="img-responsive" />
            <p>?? kr</p>
            <input type="number" value="1" id="itemCounter" />
            <button type="button" class="btn btn-primary addToCartButton">Köp</button>
            <p>BESKRIVNING</p>
        </div>
    </div>
</asp:Content>
