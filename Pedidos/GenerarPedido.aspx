<%@ Page Title="Mi pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarPedido.aspx.cs" Inherits="Pedidos.GenerarPedido1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="">
        <div class="">
            <div class="">
                <label style="font-weight: 900; color: red;">Pedido a nombre de</label>
                <asp:TextBox Style="font-weight: 700;" ID="txtnombre" runat="server" CssClass="inputs" placeholder="Nombre"></asp:TextBox>
                <label style="font-weight: 900; color: red;">Dirección</label>
                <asp:TextBox ID="txtdireccion" Style="font-weight: 700;" runat="server" CssClass="inputs" placeholder="Ingrese su dirección"></asp:TextBox>
                <label style="font-weight: 900; color: red;">Fecha de entrega</label>
                <asp:TextBox ID="txtfecha" Style="font-weight: 700;" type="date" runat="server" CssClass="inputs" placeholder="Edad"></asp:TextBox>
                <label style="font-weight: 900; color: red;">Hora</label>
                <asp:TextBox ID="txthora" Style="font-weight: 700;" type="time" runat="server" CssClass="inputs" placeholder="Edad"></asp:TextBox>
                <asp:Label ID="lbltotal" Style="font-weight: 900; color: green; font-size: 15px;" CssClass="pb-2" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblerrorpedido1" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Button ID="PedidoDomicilio" runat="server" Text="Generar pedido" CssClass="button" OnClick="PedidoDomicilio_Click" />
            </div>
        </div>
        <div class="">
            <div class="">
                <h1>Pedido hasta la puerta de tu casa.</h1>
                <br />
                <label class="ghost button" id="signUp">Realizar mi pedido</label>
            </div>
        </div>
    </div>
    <div class="">
        <div class="">
            <label style="font-weight: 900; color: red;">Pedido a nombre de</label>
            <asp:TextBox Style="font-weight: 700;" ID="txtnombre2" runat="server" CssClass="inputs" placeholder="Nombre"></asp:TextBox>
            <label style="font-weight: 900; color: red;">Fecha de entrega</label>
            <asp:TextBox ID="txtfecha2" Style="font-weight: 700;" type="date" runat="server" CssClass="inputs" placeholder="Edad"></asp:TextBox>
            <label style="font-weight: 900; color: red;">Hora</label>
            <asp:TextBox ID="txthora2" Style="font-weight: 700;" type="time" runat="server" CssClass="inputs" placeholder="Edad"></asp:TextBox>
            <asp:Label ID="lbltotal2" Style="font-weight: 900; color: green; font-size: 15px;" CssClass="pb-2" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblerrorpedido2" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Button ID="PedidoNormal" runat="server" Text="Generar pedido" CssClass="button" OnClick="PedidoNormal_Click" />
        </div>
    </div>
</asp:Content>

