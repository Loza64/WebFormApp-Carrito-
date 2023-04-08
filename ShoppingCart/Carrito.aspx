<%@ Page Title="My Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ShoppingCart.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="pt-5">
        <h2 class="text-center">Mi carrito de compras</h2>
        <div class="flex-carrito">
            <div class="contenedor-carrito">
                <table>
                    <thead>
                        <tr>
                            <th class="d-none">Id</th>
                            <th class="dis-none">Producto</th>
                            <th>Nombre</th>
                            <th>Precio</th>
                            <th>Cant</th>
                            <th>SubTotal</th>
                            <th class="dis-none">Total</th>
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
                                        <asp:Image ID="imgproducto" runat="server" />
                                    </td>
                                    <td>
                                        <%#Eval("Nombre") %>
                                    </td>
                                    <td class="item-price">
                                        <%#"$"+ Eval("Precio") %>
                                    </td>
                                    <td>
                                        <div class="flex-buttoms">
                                            <asp:LinkButton ID="btnresta" runat="server" CommandName="Restar" class="fas fa-minus btn-quantity" />
                                            <asp:Label type="number" CssClass="cantidad text-center" ID="txtcantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                            <asp:LinkButton ID="btnsuma" runat="server" CommandName="Sumar" class="fas fa-plus btn-quantity" />
                                        </div>
                                    </td>
                                    <td class="item-price">
                                        <%#"$"+ Eval("SubTotal") %>
                                    </td>
                                    <td class="item-price dis-none">
                                        <%#"$"+ Eval("Total") %>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:LinkButton ID="btneliminar" runat="server" CommandName="Eliminar" class="textoboton fas fa-trash" />
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
                    <asp:Button ID="btnpedido" runat="server" Text="Generar mi pedido" CssClass="botonpedido" OnClick="btnpedido_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
