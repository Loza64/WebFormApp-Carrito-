using Entities;
using Logic;
using Pedidos.Custom;
using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Net.Mail;
using System.Web.Security;

namespace Pedidos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserSession"] = null;
            }
        }

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

        private Usuario getEntities()
        {
            Usuario usuario = new Usuario();
            usuario.Username = txtusuario.Text;
            usuario.Nombres = txtnombres.Text;
            usuario.Apellidos = txtapellidos.Text;
            usuario.Edad = Convert.ToInt32(txtedad.Text);
            usuario.Telefono = txttelefono.Text;
            usuario.Email = txtemail.Text;
            usuario.Password = txtpassword.Text;
            usuario.Genero = ddlgenero.Text;
            return usuario;
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario login = UsuarioLN.GetInstance().Login(txtusuario2.Text, txtpassword2.Text);
                if (login != null)
                {
                    SessionManager _SessionManager = new SessionManager(Session);
                    _SessionManager.UserSession = login;
                    FormsAuthentication.RedirectFromLoginPage(txtusuario2.Text, false);
                    Response.Redirect("~/Principal.aspx");
                }
                else
                {
                    
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
            if (string.IsNullOrEmpty(txtapellidos.Text) || string.IsNullOrEmpty(txtpassword.Text) || string.IsNullOrEmpty(txtedad.Text) || string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtnombres.Text) || string.IsNullOrEmpty(txtusuario.Text) || string.IsNullOrEmpty(txttelefono.Text))
            {
                
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
                        
                    }
                    else
                    {
                       
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
    }
}