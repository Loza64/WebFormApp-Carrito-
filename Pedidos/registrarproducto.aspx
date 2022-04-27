<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrarproducto.aspx.cs" Inherits="Pedidos.registrarproducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Nuevo producto</title>
    <link href="css/Style.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.18/dist/sweetalert2.all.min.js"></script>
</head>
<body class="cuerpo">
    <div class="contenedor-formulario">
        <form id="form1" runat="server" class="formulario">
            <h3 class="text-center">Registrar producto</h3>
            <div>
                <label>Imagen del producto</label>
            </div>
            <div class="input">
                <asp:FileUpload ID="archivo" runat="server" />
            </div>
            <br />
            <div>
                <label>Nombre</label>
            </div>
            <div>
                <asp:TextBox ID="txtnombre" runat="server" CssClass="input"></asp:TextBox>
            </div>

            <br />
            <div>
                <label>Descripcion</label>
            </div>
            <div>
                <asp:TextBox ID="txtdescripcion" runat="server" CssClass="input"></asp:TextBox>
            </div>

            <br />
            <div>
                <label>precio</label>
            </div>
            <div>
                <asp:TextBox ID="txtprecio" runat="server" CssClass="input"></asp:TextBox>
            </div>

            <br />
            <div>
                <label>Stock</label>
            </div>
            <div>
                <asp:TextBox ID="txtstock" type="number" runat="server" CssClass="input"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="Button1" CssClass="btn btn-warning" style="font-weight:900; margin-top:13px" runat="server" Text="subirarticulo" OnClick="Button1_Click" />
            </div>
        </form>
    </div>


</body>
</html>
