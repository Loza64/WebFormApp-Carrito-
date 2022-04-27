using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pedidos
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                if (Session["Item"] != null)
                {
                    lblcuenta.Text = (string)Session["Item"];
                }
                else
                {
                    lblcuenta.Text = "0";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}