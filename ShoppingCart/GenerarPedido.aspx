<%@ Page Title="Mi pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarPedido.aspx.cs" Inherits="ShoppingCart.GenerarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contenedor">
        <div class="form-container">
            <div class="formulario">
                <div class="login-container">
                    <h1>Reservar pedido</h1>
                    <label style="font-weight: 900; color: red;">Pedido a nombre de</label>
                    <asp:TextBox Style="font-weight: 700;" ID="txtnombre2" runat="server" CssClass="texto" placeholder="Nombre"></asp:TextBox>
                    <label style="font-weight: 900; color: red;">Fecha de entrega</label>
                    <asp:TextBox ID="txtfecha2" Style="font-weight: 700;" type="date" runat="server" CssClass="texto" placeholder="Edad"></asp:TextBox>
                    <label style="font-weight: 900; color: red;">Hora</label>
                    <asp:TextBox ID="txthora2" Style="font-weight: 700;" type="time" runat="server" CssClass="texto" placeholder="Edad"></asp:TextBox>
                    <asp:Label ID="lbltotal2" Style="font-weight: 900; color: green; font-size: 15px;" CssClass="pb-1" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblerrorpedido2" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Button ID="PedidoNormal" runat="server" Text="Generar pedido" CssClass="form-buttom" OnClick="PedidoNormal_Click" />
                </div>
            </div>
            <div class="contenido">
                <label>Pedidos hasta la puerta de tu casa.</label>
                <div class="buttom-tranparent" id="open-modal">Realizar mi pedido ahora</div>
            </div>
        </div>
    </div>
    <div class="contenedor-modal" id="modal">
        <div class="signup-container" id="form-signup">
            <div class="form-buttom-close">
                <i class="fas fa-times" id="close-modal"></i>
            </div>
            <label style="font-weight: 900; color: red;">Pedido a nombre de</label>
            <asp:TextBox Style="font-weight: 700;" ID="txtnombre" runat="server" CssClass="texto" placeholder="Nombre"></asp:TextBox>
            <label style="font-weight: 900; color: red;">Dirección</label>
            <asp:TextBox ID="txtdireccion" Style="font-weight: 700;" runat="server" CssClass="texto" placeholder="Ingrese su dirección"></asp:TextBox>
            <label style="font-weight: 900; color: red;">Fecha de entrega</label>
            <asp:TextBox ID="txtfecha" Style="font-weight: 700;" type="date" runat="server" CssClass="texto" placeholder="Edad"></asp:TextBox>
            <label style="font-weight: 900; color: red;">Hora</label>
            <asp:TextBox ID="txthora" Style="font-weight: 700;" type="time" runat="server" CssClass="texto" placeholder="Edad"></asp:TextBox>
            <asp:Label ID="lbltotal" Style="font-weight: 900; color: green; font-size: 15px;" CssClass="pb-1" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblerrorpedido1" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Button ID="PedidoDomicilio" runat="server" Text="Generar pedido" CssClass="form-buttom" OnClick="PedidoDomicilio_Click" />
        </div>
    </div>
</asp:Content>
