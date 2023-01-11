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
                lblcuenta.Text = ((List<ListadoCarrito>)Session["carrito"]).Count.ToString();
                if (Session["UserSession"] != null)
                {
                    lblLogin.Text = "Mi perfil";
                }
                else
                {
                    lblLogin.Text = "Iniciar sesión";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


        }
    }
}