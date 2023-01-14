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
            return new Usuario
            {
                Username = txtusuario.Text,
                Nombres = txtnombres.Text,
                Apellidos = txtapellidos.Text,
                Edad = Convert.ToInt32(txtedad.Text),
                Telefono = txttelefono.Text,
                Email = txtemail.Text,
                Password = txtpassword.Text,
                Genero = ddlgenero.Text
            };
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
                    Response.Redirect("/Products");
                }
                else
                {
                    lblerrorlogin.Visible = true;
                    lblerrorlogin.Text = "Usuario o contraseña incorrectos.";
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
            if (string.IsNullOrEmpty(txtapellidos.Text) || string.IsNullOrEmpty(txtpassword.Text) || string.IsNullOrEmpty(txtedad.Text) || string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtnombres.Text) || string.IsNullOrEmpty(txtusuario.Text) || string.IsNullOrEmpty(txttelefono.Text) || ddlgenero.Text == "Genero")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "errorSignup()", true);
            }
            else if (!emailconfimr(txtemail.Text))
            {
                txtemail.Text = "Email no valido";
                txtemail.BorderColor = Color.Red;
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "errorSignup()", true);
            }
            else if (!edadconfirm(txtedad.Text))
            {
                txtedad.Text = "Edad no valida";
                txtedad.BorderColor = Color.Red;
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "errorSignup()", true);
            }
            else
            {
                try
                {
                    Usuario usuario = getEntities();
                    bool SingIn = UsuarioLN.GetInstance().SignUp(usuario);
                    if (SingIn)
                    {
                        lblsuccessignup.Visible = true;
                        lblsuccessignup.Text = "Registro realizado exitosamente.";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "succesSignup('Pedidos Store','" + usuario.Username + "')", true);
                    }
                    else
                    {
                        lblerrorsignup.Visible = true;
                        lblerrorsignup.Text = "Usuario, correo o teléfono ya son usados por otro usuario.";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "errorSignupData()", true);
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