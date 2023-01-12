<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pedidos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contenedor">
        <div class="form-container">
            <div class="formulario">
                <div class="login-container">
                    <h1>Iniciar sesión</h1>
                    <asp:TextBox ID="txtusuario2" runat="server" placeholder="Usuario" CssClass="texto"></asp:TextBox>
                    <asp:TextBox ID="txtpassword2" runat="server" placeholder="Contraseña" CssClass="texto" type="password"></asp:TextBox>
                    <asp:Button ID="btnlogin" runat="server" Text="Iniciar sesión" CssClass="form-buttom" OnClick="btnlogin_Click" />
                    <a href="#">¿Olvidaste tu contraseña?</a>
                </div>
            </div>
            <div class="contenido">
                <label>Crea tu cuenta de usuario y realiza tus pedidos ahora en pedidos store.</label>
                <div class="buttom-tranparent" id="open-modal">Crear cuenta de usuario</div>
            </div>
        </div>
    </div>
    <div class="contenedor-modal" id="modal">
        <div class="signup-container" id="form-signup">
            <div class="form-buttom-close">
                <i class="fas fa-times" id="close-modal"></i>
            </div>
            <asp:TextBox ID="txtusuario" runat="server" placeholder="Usuario" CssClass="texto"></asp:TextBox>
            <div>
                <asp:TextBox ID="txtnombres" runat="server" placeholder="Nombres" CssClass="texto"></asp:TextBox>
                <asp:TextBox ID="txtapellidos" runat="server" placeholder="Apellidos" CssClass="texto"></asp:TextBox>
            </div>
            <div>
                <asp:DropDownList ID="ddlgenero" runat="server" CssClass="texto">
                    <asp:ListItem>Genero</asp:ListItem>
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Femenino</asp:ListItem>
                    <asp:ListItem>Prefiero no decirlo</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtedad" runat="server" placeholder="Edad" CssClass="texto" type="number" min="1"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtemail" runat="server" placeholder="Email" CssClass="texto" type="email"></asp:TextBox>
                <asp:TextBox ID="txttelefono" runat="server" placeholder="Teléfono" CssClass="texto"></asp:TextBox>
            </div>
            <asp:TextBox ID="txtpassword" runat="server" placeholder="contraseña" CssClass="texto" type="password"></asp:TextBox>
            <asp:Button ID="btnsignup" runat="server" Text="Registrarme" CssClass="form-buttom" OnClick="btnsignup_Click" />
        </div>
    </div>
</asp:Content>
