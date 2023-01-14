<%@ Page Title="Buscar producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchProduct.aspx.cs" Inherits="Pedidos.SearchProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <section class="seccion-search pt-5">
        <h1>Resultados de busqueda</h1>
        <asp:Repeater ID="ListProducts" runat="server" OnItemCommand="ListProductsCommand" OnItemDataBound="ListProductsDataBound">
            <ItemTemplate>
                <div class="targeta2" id="target">
                    <div class="producto-img">
                        <asp:ImageButton ID="imgproducto" CssClass="imgproducto" runat="server" CommandName="detalles" ImageUrl='<%#"data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) %>' />
                    </div>
                    <div class="content-targeta2">
                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("Id") %>' CssClass="d-none"></asp:Label>
                        <asp:Label ID="lblidcategoria" runat="server" Text='<%# Eval("IdCategoria") %>' CssClass="d-none"></asp:Label>
                        <div class="flex-targeta2">
                            <h2><%# Eval("Nombre") %></h2>
                            <asp:Label ID="lblestado" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                        </div>
                        <label class="details"><%#Eval("Detalle") %></label>
                        <div class="details2">
                            <asp:Label ID="lblcategoria" runat="server"></asp:Label>
                            <label class="price">Hecho por: <%#Eval("Company") %></label>
                            <label class="price">US$<%#Eval("Precio") %></label>
                            <div class="stock">
                                <i class="fas fa-box-open"></i>
                                <label><%# Eval("Stock") %></label>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </section>

</asp:Content>
