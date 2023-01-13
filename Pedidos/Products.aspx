<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Pedidos.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container   pt-5">
        <div class="container-fluid">
            <div class="row">
                <asp:Repeater ID="Productslist" runat="server" OnItemCommand="ProductslistCommand" OnItemDataBound="ProductslistDataBound">
                    <ItemTemplate>
                        <div class="col-md-4 my-2">
                            <div class="targeta">
                                <div class="cabeza-targeta">
                                    <asp:Label ID="txtid" runat="server" Text='<%# Eval("Id") %>' Style="display: none"></asp:Label>
                                    <asp:Label ID="txtnombre" runat="server" Text='<%# Eval("Nombre")%>' CssClass="nombreproducto"></asp:Label>
                                    <div class="labelstock">
                                        <i class="fas fa-box-open"></i>
                                        <asp:Label ID="Stock" runat="server" Text='<%# Eval("Stock") %>' Style="font-weight: 900"></asp:Label>
                                    </div>
                                </div>
                                <div style="display: flex; justify-content: space-between; align-items: center; width: 100%">
                                    <asp:Label Style="font-weight: 800; font-size: 15px;" ID="lblprecio" runat="server" Text='<%#"$"+Eval("Precio") %>'></asp:Label>
                                    <asp:Label ID="lblestado" runat="server" Text='<%# Eval("Estado")%>' Style="font-weight: 700"></asp:Label>
                                </div>
                                <div class="cuerpo-targeta">
                                    <img class="imagenproducto" src="<%#"data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) %>" />
                                </div>
                                <div class="pie-targeta">
                                    <div class="botones">
                                        <asp:Button ID="btncarrito" CommandName="carrito" runat="server" Text="Añadir al carrito" CssClass="botoncarrito"></asp:Button>
                                        <asp:Button ID="btndetalleproducto" CommandName="detalle" runat="server" Text="Mostrar detalles" CssClass="botondetalle" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
