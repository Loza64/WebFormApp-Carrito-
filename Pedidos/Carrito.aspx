<%@ Page Title="Mi carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Pedidos.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="pt-5">
        <h2 class="text-center"> <i class="fas fa-shopping-cart "></i> Tu carrito de compras<i class="fas fa-shopping-cart "></i></h2>
        <div class="row pt-2">
            <div class="col-sm-8">
                <div class=" tabla table-responsive mb-3">
                    <asp:DataList ID="CarritoCompras" runat="server" OnItemCommand="CarritoCompras_ItemCommand2" OnItemDataBound="CarritoCompras_ItemDataBound" Width="100%">
                        <ItemTemplate>
                            <div class="cuerpotabla">
                                <td class="d-none">
                                    <asp:Label ID="lblidproducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
                                </td>
                                <td class="texto celda">
                                    <asp:Label ID="lblnombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                </td>
                                <td class="texto celda">
                                    <asp:Image ID="imgproducto" runat="server" ImageUrl='<%#Bind("Imagen") %>' CssClass="imgproducto"  />
                                </td>
                                <td class="texto celda precio">
                                    <label>US$<asp:Label ID="lblprecio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label></label>
                                </td>
                                <td class="texto celda">
                                    <div class="botones">
                                        <asp:LinkButton ID="btnresta" runat="server" CommandName="Restar" class="fas fa-minus btncantidad" />
                                        <asp:Label type="number" Enabled="false" CssClass="cantidad text-center" CommandName="Cantidad" Style="" ID="txtcantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                        <asp:LinkButton ID="btnsuma" runat="server" CommandName="Sumar" class="fas fa-plus btncantidad" />
                                    </div>
                                </td>
                                <td class="texto celda precio">
                                    <asp:Label ID="lblsubtotal" runat="server" Text='<%# Bind("SubTotal") %>'></asp:Label>/ST</td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="btneliminar" runat="server" CommandName="Eliminar" class="textoboton btn btn-danger fas fa-trash" />
                                    </div>
                                </td>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>

            <div class="col-sm-4">
                <div class="formulariopago mb-3">
                    <div>
                        <div>
                            <label>SubTotal</label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtsubtotal" runat="server" Enabled="false" CssClass="textopago text-success text-center"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <div>
                            <label>Impuesto</label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtiva" runat="server" Enabled="false" CssClass="textopago text-success text-center"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <div>
                            <label>Total</label>
                        </div>
                        <div>
                            <asp:TextBox ID="txttotal" runat="server" Enabled="false" CssClass="textopago text-success text-center"></asp:TextBox>
                        </div>
                    </div>
                    <div class="pb-3">
                        <asp:Button ID="btnpedido" runat="server" Text="Generar mi pedido" CssClass="botonpedido" OnClick="btnpedido_Click" />
                    </div>
                </div>
            </div>


        </div>
    </div>


</asp:Content>
