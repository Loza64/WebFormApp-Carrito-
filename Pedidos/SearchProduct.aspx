<%@ Page Title="Buscar producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchProduct.aspx.cs" Inherits="Pedidos.SearchProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="seccion-search pt-5 container">
        <h1>Resultados</h1>
        <asp:Repeater ID="ListProducts" runat="server">
            <ItemTemplate>

            </ItemTemplate>
        </asp:Repeater>
    </section>

</asp:Content>
