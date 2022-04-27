<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pedidos.Acces.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar Sesión</title>
    <link href="../css/formloginstyle.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.18/dist/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <script src="../JS/script.js"></script>
</head>
<body class="body-login">
    <form id="form1" runat="server">
        <div class="containercss" id="container" style="margin-top:-20px;">
            <div class="form-container sign-up-container">
                <div class="form">
                    <asp:TextBox Style="font-weight: 700;" ID="txtusuario" runat="server" CssClass="input" placeholder="Usuario"></asp:TextBox>
                    <asp:TextBox Style="font-weight: 700;" ID="txtnombres" runat="server" CssClass="input" placeholder="Nombres"></asp:TextBox>
                    <asp:TextBox Style="font-weight: 700;" ID="txtapellidos" runat="server" CssClass="input" placeholder="Apellidos"></asp:TextBox>
                    <asp:DropDownList Style="font-weight: 700;" ID="ddlgenero" runat="server" CssClass="input">
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                        <asp:ListItem>Indefinido</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox Style="font-weight: 700;" ID="txtedad" runat="server" CssClass="input" placeholder="Edad"></asp:TextBox>
                    <asp:TextBox Style="font-weight: 700;" ID="txtemail" runat="server" CssClass="input" placeholder="Email"></asp:TextBox>
                    <asp:TextBox Style="font-weight: 700;" ID="Txttelefono" runat="server" CssClass="input" placeholder="Telefono"></asp:TextBox>
                    <asp:TextBox Style="font-weight: 700;" ID="txtcontraseña" type="password" runat="server" CssClass="input" placeholder="Contraseña"></asp:TextBox>
                    <asp:Label ID="lblerrorsignup" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Button ID="btnsignup" runat="server" Text="Registrarme" CssClass="button" OnClick="btnsignup_Click" />
                </div>
            </div>
            <div class="form-container sign-in-container">
                <div class="form">
                    <h1>Iniciar Sesión</h1>
                    <div class="social-container">
                        <a href="#" class="social"><i class="fab fa-facebook"></i></a>
                        <a href="#" class="social"><i class="fab fa-google"></i></a>
                        <a href="#" class="social"><i class="fab fa-linkedin"></i></a>
                    </div>
                    <asp:TextBox Style="font-weight: 700;" ID="txtusuario2" runat="server" CssClass="input" placeholder="Usuario o email"></asp:TextBox>
                    <asp:TextBox Style="font-weight: 700;" ID="txtcontraseña2" type="password" runat="server" CssClass="input" placeholder="Contraseña"></asp:TextBox>
                    <asp:Label ID="lblerrorlogin" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                    <br />
                    <asp:Button ID="btnlogin" runat="server" Text="Iniciar Sesión" CssClass="button" OnClick="btnlogin_Click" />
                </div>
            </div>
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-panel overlay-left">
                        <h1 style="font-size:40px">Iniciar Sesión</h1>
                        <p style="font-size:20px">Despues de registrarte podras acceder sin problemas a nuestro sitio web.</p>
                        <label class="ghost button" id="signIn">Iniciar Sesión</label>
                    </div>
                    <div class="overlay-panel overlay-right">
                        <h1 style="font-size:40px">Crear mi cuenta de usuario</h1>
                        <p style="font-size:20px">Ingresa tus datos personales para registrarte en nuestro sitio web y así puedas acceder.</p>
                        <label class="ghost button" id="signUp">Registrarme</label>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../JS/main.js"></script>
</body>
</html>
