<%@ Page Title="Detalles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Pedidos.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <section class="container pt-5">
        <h2 class="text-center nombreproducto2">
            <asp:Label ID="lblnombreproducto" runat="server"></asp:Label></h2>
        <div class="flex m-2">
            <div class="productoimg">
                <asp:Image ID="imgproduct" runat="server" alt="Producto" CssClass="img" />
            </div>
            <div class="contenidoproducto">
                <h4 class="nombreproducto">Hecho por:
                    <asp:Label ID="lblcompany" runat="server"></asp:Label>
                </h4>
                <h4 class="precio">
                    Precio: $<asp:Label ID="lblprecio" runat="server"></asp:Label>
                </h4>
                <h4 style="font-weight: 700">Stock: 
                    <i class="fa fa-gift"></i><asp:Label ID="lblstock" runat="server"></asp:Label>
                </h4>
                <label style="font-weight: 700; font-size: 24px">Acerca del producto:</label><asp:Label ID="lbldescripcion" runat="server" class="descripcionproducto"></asp:Label>
                <div class="flex">
                    <asp:Button ID="btncarrito" runat="server" Text="Añadir al carrito" class="botoncarrito" OnClick="btncarrito_Click" />
                    <asp:Button ID="btnprincipal" runat="server" Text="Volver al area principal" class="botondetalle" OnClick="btnprincipal_Click1" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
