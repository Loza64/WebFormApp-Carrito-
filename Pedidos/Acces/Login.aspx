<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pedidos.Acces.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar Sesión</title>
    <link href="~/pedidos.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.18/dist/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link rel="stylesheet" href="../css/LoginStyle.css" />
</head>
<body>
    <div class="contenedor-formulario">
        <form id="form1" runat="server" class="formulario">
            <div class="login-container">
                <asp:TextBox ID="txtusuario2" runat="server" placeholder="Usuario" CssClass="texto"></asp:TextBox>
                <asp:TextBox ID="txtpassword2" runat="server" placeholder="Contraseña" CssClass="texto"></asp:TextBox>
                <asp:Button ID="btnlogin" runat="server" Text="Iniciar sesión" CssClass="boton" OnClick="btnLogin_Click1" />
            </div>
            <div class="signup-container">
                <asp:TextBox ID="txtusuario" runat="server" placeholder="Usuario" CssClass="texto"></asp:TextBox>
                <div>
                    <asp:TextBox ID="txtnombres" runat="server" placeholder="Nombres" CssClass="texto"></asp:TextBox>
                    <asp:TextBox ID="txtapellidos" runat="server" placeholder="Apellidos" CssClass="texto"></asp:TextBox>
                </div>
                <div>
                    <asp:DropDownList ID="ddlgenero" runat="server" CssClass="texto">
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                        <asp:ListItem>Prefiero no decirlo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtedad" runat="server" placeholder="Edad" CssClass="texto" type="number" min="1"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="txtemail" runat="server" placeholder="Correo electronico" CssClass="texto" type="email"></asp:TextBox>
                    <asp:TextBox ID="txttelefono" runat="server" placeholder="Numero de teléfono" CssClass="texto"></asp:TextBox>
                </div>
                <asp:TextBox ID="txtpassword" runat="server" placeholder="contraseña" CssClass="texto"></asp:TextBox>
                <asp:Button ID="btnsignup" runat="server" Text="Registrarme" CssClass="boton" OnClick="btnLogin_Click1" />
            </div>
        </form>
        <div class="content-form">
        </div>
    </div>
</body>
</html>
