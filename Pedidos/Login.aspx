<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pedidos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/LoginStyle.css" rel="stylesheet" />
    <div class="contenedor">
        <div class="form-container">
            <div class="formulario">
                <div class="login-container">
                    <h1>Iniciar sesión</h1>
                    <asp:TextBox ID="txtusuario2" runat="server" placeholder="Usuario" CssClass="texto"></asp:TextBox>
                    <asp:TextBox ID="txtpassword2" runat="server" placeholder="Contraseña" CssClass="texto"></asp:TextBox>
                    <asp:Button ID="btnlogin" runat="server" Text="Iniciar sesión" CssClass="form-buttom"  />
                </div>
            </div>
            <div class="contenido">
                <label>Crea tu cuenta de usuario y realiza tus pedidos ahora en pedidos store.</label>
            </div>
        </div>
    </div>
</asp:Content>
