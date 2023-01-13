using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosStore
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
    }
}