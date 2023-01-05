using Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Pedidos
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["carrito"] == null)
                {
                    Session["carrito"] = new List<ListadoCarrito>();
                }
                if (Session["UserSession"] != null)
                {
                    Usuario user = (Usuario)Session["UserSession"];
                    if (user != null)
                    {
                        lblusuario.Text = user.Email;
                        lblacceder.Text = "Cerrar Sesión";
                    }
                    else
                    {
                        lblacceder.Text = "Iniciar Sesión";
                    }
                }
                lblcuenta.Text = ((List<ListadoCarrito>)Session["carrito"]).Count.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


        }
    }
}