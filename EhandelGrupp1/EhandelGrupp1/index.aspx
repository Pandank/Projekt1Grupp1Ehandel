<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EhandelGrupp1.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Literal ID="LiteralStart" runat="server"></asp:Literal>
        <asp:Literal ID="LiteralCategory" runat="server"></asp:Literal>
        <div id="productSite">

            <asp:Literal ID="LiteralProduct" runat="server"></asp:Literal>
        </div>
    </div>

</asp:Content>
