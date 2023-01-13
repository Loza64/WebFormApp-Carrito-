<%@ Page Title="Detalle producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Pedidos.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container details-product" style="padding-top:80px;">
        <h2 class="text-center nombreproducto2">
            <asp:Label ID="lblnombreproducto" runat="server"></asp:Label>
        </h2>
        <div class="flex">
            <div class="productoimg">
                <asp:Image ID="imgproduct" runat="server" alt="Producto" CssClass="img" />
            </div>
            <div>
                <h4 class="nombreproducto3">
                    Hecho por: <asp:Label ID="lblcompany" runat="server"></asp:Label>
                </h4>
                <h4 class="precio2">
                    Precio: $<asp:Label ID="lblprecio" runat="server"></asp:Label>
                </h4>
                <h4 class="stock">
                    Stock: <i class="fa fa-gift"></i><asp:Label ID="lblstock" runat="server"></asp:Label>
                </h4>
                <label style="font-weight: 700; font-size: 24px">Acerca del producto: </label>
                <asp:Label ID="lbldescripcion" runat="server" class="descripcionproducto"></asp:Label>
                <div class="flex" style="margin:5px 0">
                    <asp:Button ID="btncarrito" runat="server" Text="Añadir al carrito" class="botoncarrito" OnClick="btncarrito_Click" />
                    <asp:Button ID="btnprincipal" runat="server" Text="Volver al area principal" class="botondetalle" OnClick="btnprincipal_Click1" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
