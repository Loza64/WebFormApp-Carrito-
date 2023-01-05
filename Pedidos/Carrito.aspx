<%@ Page Title="Mi carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Pedidos.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="pt-5">
        <h2 class="text-center"> <i class="fas fa-shopping-cart "></i> Mi carrito de compras <i class="fas fa-shopping-cart "></i></h2>
        <div class="flex-carrito">
            <div class="contenedor-carrito">
                <table>
                    <thead>
                        <tr>
                            <th class="d-none">Id</th>
                            <th class="dis-none">Producto</th>
                            <th>Descripción</th>
                            <th>Precio</th>
                            <th>Cantidad</th>
                            <th>Subtotal</th>
                            <th>Quitar</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="carrito" runat="server" OnItemCommand="ItemCommanCarrito" OnItemDataBound="ItemDataBoundCarito">
                            <ItemTemplate>
                                <tr>
                                    <td class="d-none">
                                        <asp:Label ID="lblidproducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
                                    </td>
                                    <td class="dis-none">
                                        <img src="<%#Eval("Imagen")%>" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblnombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblprecio" runat="server" Text='<%# "$"+Eval("Precio") %>' CssClass="item-price"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="flex-buttoms">
                                            <asp:LinkButton ID="btnresta" runat="server" CommandName="Restar" class="fas fa-minus btn-quantity" />
                                            <asp:Label type="number" CssClass="cantidad text-center" CommandName="Cantidad" ID="txtcantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                            <asp:LinkButton ID="btnsuma" runat="server" CommandName="Sumar" class="fas fa-plus btn-quantity" />
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblsubtotal" runat="server" Text='<%#"$"+ Eval("SubTotal") %>' CssClass="item-price"></asp:Label></td>
                                    <td>
                                        <div>
                                            <asp:LinkButton ID="btneliminar" runat="server" CommandName="Eliminar" class="textoboton btn btn-danger fas fa-trash" />
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="contenedor-formulario">
                <div class="form-pago">
                    <label>SubTotal</label>
                    <asp:TextBox ID="txtsubtotal" runat="server" Enabled="false" CssClass="textopago"></asp:TextBox>
                    <label>Impuesto</label>
                    <asp:TextBox ID="txtiva" runat="server" Enabled="false" CssClass="textopago"></asp:TextBox>
                    <label>Total</label>
                    <asp:TextBox ID="txttotal" runat="server" Enabled="false" CssClass="textopago"></asp:TextBox>
                    <asp:Button ID="btnpedido" runat="server" Text="Generar mi pedido" CssClass="botonpedido" OnClick="btnpedido_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
