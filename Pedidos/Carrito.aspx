<%@ Page Title="Mi carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Pedidos.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div class="pt-5">
        <h2 class="text-center">Mi carrito de compras <i class="fas fa-shopping-cart "></i></h2>
        <div class="row pt-2">
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

            <div class="col-sm-8">
                <div class="table-responsive mb-3" style="width: 100%; overflow: no-display; height: 410px">
                    <asp:DataList ID="CarritoCompras" runat="server" OnItemCommand="CarritoCompras_ItemCommand2">
                        <ItemTemplate>
                            <tr class="cuerpotabla">
                                <td class="d-none">
                                    <asp:Label ID="lblitem" runat="server" Text='<%# Bind("Item") %>'></asp:Label></td>
                                <td class="d-none">
                                    <asp:Label ID="lblidproducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label></td>
                                <td class="texto celda">
                                    <asp:Label ID="lblnombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label></td>
                                <td class="texto celda">
                                    <asp:Image ID="imgproducto" runat="server" ImageUrl='<%#Bind("Imagen") %>' CssClass="imgproducto" Style="width: 80px; height: 80px;" /></td>
                                <td class="textodescripcion celda celdadescripcion text-center">
                                    <asp:Label ID="lbldescripcion" runat="server" Text='<%# Bind("Descripción") %>'></asp:Label></td>
                                <td class="texto celda text-success">
                                    <label>$<asp:Label ID="lblprecio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label></label>
                                </td>
                                <td class="texto celda text-center">
                                    <div class="d-flex">
                                        <asp:LinkButton ID="btnsuma" runat="server" CommandName="sumar" class=" btn btn-light fas fa-plus" />
                                        <asp:TextBox type="number" Enabled="false" CssClass="form-control text-center" CommandName="Cantidad" Style="width: 40px; padding: 0; margin: 0; font-weight: 700" ID="txtcantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                                        <asp:LinkButton ID="btnresta" runat="server" CommandName="restar" class=" btn btn-light fas fa-minus" />
                                    </div>
                                </td>
                                <td class="texto celda text-success">
                                    <asp:Label ID="lblsubtotal" runat="server" Text='<%# Bind("SubTotal") %>'></asp:Label>/ST</td>
                                <td>
                                    <asp:LinkButton ID="btneliminar" runat="server" CommandName="Eliminar" class="textoboton btn btn-danger fas fa-trash" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
