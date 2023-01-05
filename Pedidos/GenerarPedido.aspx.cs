using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;

namespace Pedidos
{
    public partial class GenerarPedido1 : System.Web.UI.Page
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

                    if (Session["carrito"] != null)
                    {
                        ;
                        if (((List<ListadoCarrito>)Session["carrito"]).Count != 0)
                        {
                            lbltotal.Text = "Total a pagar: $" + ((double)Session["Total"]).ToString();
                            lbltotal2.Text = "Total a pagar: $" + ((double)Session["Total"]).ToString();
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

        protected void PedidoDomicilio_Click(object sender, EventArgs e)
        {
            long codpedido = PedidoLN.GetInstance().CodPedido() + 1;
            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtdireccion.Text) || string.IsNullOrEmpty(txtfecha.Text) || string.IsNullOrEmpty(txthora.Text))
            {
                lblerrorpedido1.Text = "Llene todos los campos por favor";
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
                Pedido pedido = new Pedido
                {
                    IdUsuario = user.Id,
                    NombreCliente = txtnombre.Text,
                    Direccion = txtdireccion.Text,
                    Estado = "Pendiente",
                    CodPedido = codpedido,
                    FechaEntrega = Convert.ToDateTime(txtfecha.Text),
                    HoraEntrega = Convert.ToDateTime(txthora.Text),
                    SubTotal = (double)Session["SubTotal"],
                    Total = (double)Session["Total"],
                    TipoPedido = "Domicilio"
                };
                try
                {
                    bool responce = PedidoLN.GetInstance().NewPedido(pedido, (List<ListadoCarrito>)Session["carrito"]);
                    if (responce)
                    {
                        Session["carrito"] = null;
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "load()", true);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (NullReferenceException ex)
                {
                    throw ex;
                }
                catch (TimeoutException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void PedidoNormal_Click(object sender, EventArgs e)
        {
            long codpedido = PedidoLN.GetInstance().CodPedido() + 1;

            if (string.IsNullOrEmpty(txtnombre2.Text) || string.IsNullOrEmpty(txtfecha2.Text) || string.IsNullOrEmpty(txthora2.Text))
            {
                lblerrorpedido2.Text = "Llene todos los campos por favor";
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
                try
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
                        SubTotal = (double)Session["SubTotal"],
                        Total = (double)Session["Total"],
                        TipoPedido = "Directo en pedidos store"
                    };
                    bool responce = PedidoLN.GetInstance().NewPedido(pedido, (List<ListadoCarrito>)Session["carrito"]);
                    if (responce)
                    {
                        Session["carrito"] = null;
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "load()", true);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (NullReferenceException ex)
                {
                    throw ex;
                }
                catch (TimeoutException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
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