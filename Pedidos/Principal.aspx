<%@ Page Title="Carrito Compras WebForms" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Pedidos.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container   pt-5">
        <div class="d-flex text-center pb-2" style="justify-content: center;">
            <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto " placeholder="Buscar producto" type="search">
            </asp:TextBox> <asp:LinkButton ID="btnsearch" runat="server" CssClass="boton fas fa-search" OnClick="btnsearch_Click"></asp:LinkButton>
        </div>
        <div style="display:flex;justify-content:center;align-items:center">
            <asp:DataList ID="listaproductos" runat="server" RepeatColumns="3" CssClass="row" OnItemDataBound="listaproductos_ItemDataBound" OnItemCommand="listaproductos_ItemCommand">
                <ItemTemplate>
                    <div class="targeta">
                        <div class="cabeza-targeta">
                            <asp:Label ID="txtid" runat="server" Text='<%# Bind("Id") %>' Style="display: none"></asp:Label>
                            <asp:Label ID="txtnombre" runat="server" Text='<%# Bind("Nombre")%>' CssClass="nombreproducto"></asp:Label>
                            <div style="font-size:23px;">
                                <i class="fas fa-box-open"> </i>
                                <asp:Label ID="Stock" runat="server" Text='<%# Bind("Stock") %>' style="font-weight:900"></asp:Label>
                            </div>
                        </div>
                        <div style="display:flex;justify-content:space-between;align-items:center"; width:100%">
                             <label style="font-weight:800;font-size: 20px;">US$<asp:Label ID="lblprecio" runat="server" Text='<%#Bind("Precio") %>'></asp:Label></label>
                              <asp:Label ID="lblestado" runat="server" Text='<%# Bind("Estado")%>' style="font-weight:700"></asp:Label>
                            </div>
                        <div class="cuerpo-targeta">
                            <asp:Image ID="imgproducto" runat="server" CssClass="imagenproducto" />
                        </div>
                        <div class="pie-targeta">
                            <div class="botones">
                                <asp:Button ID="btncarrito" CommandName="carrito" runat="server" Text="Añadir al carrito" CssClass="botoncarrito" ></asp:Button>
                                <asp:Button ID="btndetalleproducto" CommandName="detalle" runat="server" Text="Mostrar detalles" CssClass="botondetalle" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

    </div>
</asp:Content>
