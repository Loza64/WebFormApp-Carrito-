<%@ Page Title="Mi pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPedido.aspx.cs" Inherits="Pedidos.MiPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/stylepedido.css" rel="stylesheet" />
            <div class="containercss" id="container">
                <div class="form-container sign-up-container">
                    <div class="form">
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
                        <asp:Button ID="btnpedido1" runat="server" Text="Generar pedido" CssClass="button" OnClick="btnpedido1_Click" />
                    </div>
                </div>
                 <div class="form-container sign-in-container">
                    <div class="form">
                        <label style="font-weight: 900; color: red;">Pedido a nombre de</label>
                        <asp:TextBox Style="font-weight: 700;" ID="txtnombre2" runat="server" CssClass="inputs" placeholder="Nombre"></asp:TextBox>
                        <label style="font-weight: 900; color: red;">Fecha de entrega</label>
                        <asp:TextBox ID="txtfecha2" Style="font-weight: 700;" type="date" runat="server" CssClass="inputs" placeholder="Edad"></asp:TextBox>
                        <label style="font-weight: 900; color: red;">Hora</label>
                        <asp:TextBox ID="txthora2" Style="font-weight: 700;" type="time" runat="server" CssClass="inputs" placeholder="Edad"></asp:TextBox>
                        <asp:Label ID="lbltotal2" Style="font-weight: 900; color: green; font-size: 15px;" CssClass="pb-2" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblerrorpedido2" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Button ID="btnpedido2" runat="server" Text="Generar pedido" CssClass="button" OnClick="btnpedido2_Click" />
                    </div>
                </div>
                <div class="overlay-container">
                    <div class="overlay">
                        <div class="overlay-panel overlay-left">
                            <h1>Recojer mi pedido en pedidos store.</h1>
                            <br />
                            <label class="ghost button" id="signIn">Realizar mi pedido</label>
                        </div>
                        <div class="overlay-panel overlay-right">
                            <h1>Pedido hasta la puerta de tu casa.</h1>
                            <br />
                            <label class="ghost button" id="signUp">Realizar mi pedido</label>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
