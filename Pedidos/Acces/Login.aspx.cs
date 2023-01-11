using Entities;
using Logic;
using Pedidos.Custom;
using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;

namespace Pedidos.Acces
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["UserSession"] = null;
            }
        }
        /*
         * 
           private Usuario getEntities()
        {
            Usuario usuario = new Usuario();
            usuario.Username = txtusuario.Text;
            usuario.Nombres = txtnombres.Text;
            usuario.Apellidos = txtapellidos.Text;
            usuario.Edad = Convert.ToInt32(txtedad.Text);
            usuario.Telefono = Txttelefono.Text;
            usuario.Email = txtemail.Text;
            usuario.Password = txtcontraseña.Text;
            usuario.Genero = ddlgenero.Text;
            return usuario;
        }

         protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario login = UsuarioLN.GetInstance().Login(txtusuario2.Text, txtcontraseña2.Text);
                if (login != null)
                {
                    SessionManager _SessionManager = new SessionManager(Session);
                    _SessionManager.UserSession = login;
                    FormsAuthentication.RedirectFromLoginPage(txtusuario2.Text, false);
                    Response.Redirect("~/Principal.aspx");
                }
                else
                {
                    lblerrorlogin.ForeColor = Color.Red;
                    lblerrorlogin.Text = "Email o usuario y contraseña incorrectos.";
                    lblerrorlogin.Visible = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SqlNullValueException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnsignup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtapellidos.Text) || string.IsNullOrEmpty(txtcontraseña.Text) || string.IsNullOrEmpty(txtedad.Text) || string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtnombres.Text) || string.IsNullOrEmpty(txtusuario.Text) || string.IsNullOrEmpty(Txttelefono.Text))
            {
                lblerrorsignup.Visible = true;
                lblerrorsignup.Text = "LLene todo los campos por favor";
                lblerrorsignup.ForeColor = Color.Red;
            }
            else if (!emailconfimr(txtemail.Text))
            {
                txtemail.Text = "Email no valido";
            }
            else if (!edadconfirm(txtedad.Text))
            {
                txtedad.Text = "Edad no valida";
            }
            else
            {
                try
                {
                    Usuario usuario = getEntities();
                    bool SingIn = UsuarioLN.GetInstance().SignUp(usuario);
                    if (SingIn)
                    {
                        lblerrorsignup.Visible = true;
                        lblerrorsignup.Text = "Te has registrado de manera exitosa";
                        lblerrorsignup.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblerrorsignup.Visible = true;
                        lblerrorsignup.Text = "Email o Nombre de usuario ya son utlizados por alguien más";
                        lblerrorsignup.ForeColor = Color.Red;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (SqlNullValueException ex)
                {
                    throw ex;
                }
                catch (TimeoutException ex)
                {
                    throw ex;
                }
                catch (NullReferenceException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
         */
        private bool emailconfimr(string email)
        {
            bool responce;
            try
            {
                MailAddress mail = new MailAddress(email);
                responce = true;
            }
            catch (Exception)
            {
                responce = false;
            }
            return responce;
        }
        private bool edadconfirm(string edad)
        {
            bool responce;
            try
            {
                int Edad = Convert.ToInt32(edad);
                responce = true;
            }
            catch (Exception)
            {
                responce = false;
            }
            return responce;
        }
        /*
         
         
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
         */
        protected void btnLogin_Click1(object sender, EventArgs e)
        {

        }
    }
}