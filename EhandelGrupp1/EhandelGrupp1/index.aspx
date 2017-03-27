<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EhandelGrupp1.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="productSite"></div>
        <asp:Literal ID="LiteralStart" runat="server"></asp:Literal>
        <asp:Literal ID="LiteralCategory" runat="server"></asp:Literal>
        <asp:Literal ID="LiteralProduct" runat="server"></asp:Literal>
<%--        <div class="row">
            <div class="col-sm-12"></div>
            <h2 class="h2">Nyheter</h2>
        </div>

        <div class="row">
            <div class="col-sm-3">
                <div class="thumbnail" id="1">
                    <a class="product" href="index.aspx?id=1">
                        <img src="img/Papper.jpg" width="250" alt="" />
                        <h3 class="h3">Multicopy, koperingspapper</h3>
                        <h4 class="h4">40 kr</h4>
                    </a>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="thumbnail">
                    <a href="product.aspx">
                        <img src="img/Papper.jpg" width="250" alt="" />
                        <h3 class="h3">Multicopy, koperingspapper</h3>
                        <h4 class="h4">40 kr</h4>
                    </a>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="thumbnail">
                    <a href="product.aspx">
                        <img src="img/Papper.jpg" width="250" alt="" />
                        <h3 class="h3">Multicopy, koperingspapper</h3>
                        <h5 class="h5">40 kr</h5>
                    </a>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="thumbnail">
                    <a href="product.aspx">
                        <img src="img/Papper.jpg" width="250" alt="" />
                        <h3 class="h3">Multicopy, koperingspapper</h3>
                        <h4 class="h4">40 kr</h4>
                    </a>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">.col-sm-12</div>
        </div>--%>
    </div>

</asp:Content>
