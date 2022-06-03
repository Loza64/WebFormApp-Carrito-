using Entities;
using Logic;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;

namespace Pedidos
{
    public partial class MiPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserSession"] != null)
                {
                    Usuario user = (Usuario)Session["UserSession"];
                    txtnombre.Text = user.Nombres + " " + user.Apellidos;
                    txtnombre2.Text = user.Nombres + " " + user.Apellidos;

                    if (Session["ListaCarrito"] != null)
                    {
                        DataTable list = (DataTable)Session["ListaCarrito"];
                        if (list.Rows.Count != 0)
                        {
                            lbltotal.Text = "Total a pagar: $" + Convert.ToString((decimal)Session["Total"]);
                            lbltotal2.Text = "Total a pagar: $" + Convert.ToString((decimal)Session["Total"]);
                        }
                        else
                        {
                            Response.Redirect("Principal.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("Principal.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Acces/Login.aspx");
                }
            }
        }
        protected void btnpedido1_Click(object sender, EventArgs e)
        {
            long codpedido = PedidoLN.GetInstance().CodPedido() + 1;

            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtdireccion.Text) || string.IsNullOrEmpty(txtfecha.Text) || string.IsNullOrEmpty(txthora.Text))
            {
                lblerrorpedido1.Text = "Llene todos los capos por favor";
                lblerrorpedido1.Visible = true;
            }
            else if (!validarfecha(txtfecha.Text))
            {
                txtfecha.Text = null;
                txtfecha.BorderColor = Color.Red;
            }
            else if (Convert.ToDateTime(txtfecha.Text) <= DateTime.Now.Date)
            {
                txtfecha.Text = null;
                txtfecha.BorderColor = Color.Red;
            }
            else
            {
                Usuario user = (Usuario)Session["UserSession"];
                Pedido pedido = new Pedido()
                {
                    Direccion = txtdireccion.Text,
                    Estado = "Pendiente",
                    CodPedido = codpedido,
                    FechaEntrega = Convert.ToDateTime(txtfecha.Text),
                    HoraEntrega = Convert.ToDateTime(txthora.Text),
                    IdUsuario = user.Id,
                    NombreCliente = txtnombre.Text,
                    Total = (decimal)Session["Total"],
                    TipoPedido = "Domicilio"
                };
                bool responce = PedidoLN.GetInstance().registrarpedido(pedido, (DataTable)Session["ListaCarrito"]);
                if (responce)
                {
                    Session["ListaCarrito"] = null;
                    Session["Item"] = null;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "load()", true);
                }
            }
        }
        protected void btnpedido2_Click(object sender, EventArgs e)
        {
            long codpedido = PedidoLN.GetInstance().CodPedido() + 1;

            if (string.IsNullOrEmpty(txtnombre2.Text) || string.IsNullOrEmpty(txtfecha2.Text) || string.IsNullOrEmpty(txthora2.Text))
            {
                lblerrorpedido2.Text = "Llene todos los capos por favor";
                lblerrorpedido2.Visible = true;
            }
            else if (!validarfecha(txtfecha2.Text))
            {
                txtfecha2.Text = null;
                txtfecha2.BorderColor = Color.Red;
            }
            else if (Convert.ToDateTime(txtfecha2.Text) <= DateTime.Now.Date)
            {
                txtfecha2.Text = null;
                txtfecha2.BorderColor = Color.Red;
            }
            else
            {
                Usuario user = (Usuario)Session["UserSession"];
                Pedido pedido = new Pedido()
                {
                    Direccion = "Pedidos Store",
                    Estado = "Pendiente",
                    CodPedido = codpedido,
                    FechaEntrega = Convert.ToDateTime(txtfecha2.Text),
                    HoraEntrega = Convert.ToDateTime(txthora2.Text),
                    IdUsuario = user.Id,
                    NombreCliente = txtnombre2.Text,
                    Total = (decimal)Session["Total"],
                    TipoPedido = "Directo en pedidos store"
                };
                bool responce = PedidoLN.GetInstance().registrarpedido(pedido, (DataTable)Session["ListaCarrito"]);
                if (responce)
                {
                    Session["ListaCarrito"] = null;
                    Session["Item"] = null;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "load()", true);
                }
            }
        }
        private bool validarfecha(string fecha)
        {
            bool responce;
            try
            {
                DateTime dateTime = Convert.ToDateTime(fecha);
                responce = true;
            }
            catch (Exception)
            {
                responce = false;
            }
            return responce;
        }
    }
}