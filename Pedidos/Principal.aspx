<%@ Page Title="Carrito Compras WebForms" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Pedidos.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container   pt-5">
        <div class="d-flex text-center pb-2" style="justify-content: center;">
            <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto " placeholder="Buscar producto" type="search">
            </asp:TextBox>
            <asp:LinkButton ID="btnsearch" runat="server" CssClass="boton fas fa-search" OnClick="btnsearch_Click"></asp:LinkButton>
        </div>
        <div class="container-fluid">
            <div class="row">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="RepeaterCommand" OnItemDataBound="RepeaterDataBound">
                    <ItemTemplate>
                        <div class="col-md-4 my-2">
                            <div class="targeta">
                                <div class="cabeza-targeta">
                                    <asp:Label ID="txtid" runat="server" Text='<%# Bind("Id") %>' Style="display: none"></asp:Label>
                                    <asp:Label ID="txtnombre" runat="server" Text='<%# Bind("Nombre")%>' CssClass="nombreproducto"></asp:Label>
                                    <div class="labelstock">
                                        <i class="fas fa-box-open"></i>
                                        <asp:Label ID="Stock" runat="server" Text='<%# Bind("Stock") %>' Style="font-weight: 900"></asp:Label>
                                    </div>
                                </div>
                                <div style="display:flex; justify-content:space-between;align-items:center"; width:100%">
                                    <asp:Label Style="font-weight: 800; font-size: 15px;" ID="lblprecio" runat="server" Text='<%#"US$"+Eval("Precio") %>'></asp:Label>
                                    <asp:Label ID="lblestado" runat="server" Text='<%# Bind("Estado")%>' Style="font-weight: 700"></asp:Label>
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
