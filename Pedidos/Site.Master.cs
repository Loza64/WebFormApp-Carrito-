using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI;

namespace Pedidos
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Si la sesion del carrito acabo lo vuelve a crear
                if (Session["carrito"] == null)
                {
                    Session["carrito"] = new List<ListadoCarrito>();
                }

                //Si la sesion del usuario esta llena se muestra su username si no se cierra sesion
                if (Session["UserSession"] != null)
                {
                    lblLogin.Text = ((Usuario)Session["UserSession"]).Username + " <i class=\"fa fa-sign-out\" aria-hidden=\"true\"></i>";
                }
                else
                {
                    lblLogin.Text = "Iniciar sesión";
                }
                lblcuenta.Text = ((List<ListadoCarrito>)Session["carrito"]).Count.ToString();
            }
        }

        protected void BtnSearch(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtbuscar.Text))
                {
                    Session["SearchProduct"] = ProductoLN.GetInstance().SearchProduct(txtbuscar.Text);
                    Response.Redirect("/SearchProduct");
                }
                else
                {
                    Response.Redirect("/Products");
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