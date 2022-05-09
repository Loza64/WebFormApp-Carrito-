using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pedidos
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                double subtotal = 0.00;
                double iva = 0.00;
                double Total = 0.00;
                CarritoCompras.DataSource = Session["ListaCarrito"];
                CarritoCompras.DataBind();
                if (Session["ListaCarrito"] != null)
                {
                    foreach (DataRow datarow in ((DataTable)Session["ListaCarrito"]).Rows)
                    {
                        subtotal += Convert.ToDouble(datarow["SubTotal"].ToString());
                        iva = (double)Math.Round(subtotal * 0.13, 2, MidpointRounding.AwayFromZero);
                        Total = (double)Math.Round(iva + subtotal, 2, MidpointRounding.AwayFromZero);
                    }
                    txtsubtotal.Text = "$" + Convert.ToString(subtotal);
                    txtiva.Text = "$" + Convert.ToString(iva);
                    txttotal.Text = "$" + Convert.ToString(Total);
                    decimal MontoTotal = (decimal)Total;
                    Session["Total"] = MontoTotal;
                }
                else
                {
                    txtsubtotal.Text = "$0.00";
                    txtiva.Text = "$0.00";
                    txttotal.Text = "$0.00";
                }
            }
        }


        protected void CarritoCompras_ItemCommand2(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                CarritoCompras.SelectedIndex = e.Item.ItemIndex;
                Label lblitem = (Label)e.Item.FindControl("lblidproducto");
                deleteitem(lblitem.Text);
            }
            else if (e.CommandName == "sumar")
            {
                CarritoCompras.SelectedIndex = e.Item.ItemIndex;
                Label lblid = (Label)e.Item.FindControl("lblidproducto");
                TextBox txtcantidad = (TextBox)e.Item.FindControl("txtcantidad");
                sumar(txtcantidad.Text, lblid.Text);

            }
            else if (e.CommandName == "restar")
            {
                CarritoCompras.SelectedIndex = e.Item.ItemIndex;
                Label lblid = (Label)e.Item.FindControl("lblidproducto");
                TextBox txtcantidad = (TextBox)e.Item.FindControl("txtcantidad");
                restar(txtcantidad.Text, lblid.Text);
            }
        }
        private void sumar(string cantidad, string item)
        {
            DataTable datatable = (DataTable)Session["ListaCarrito"];
            int cant = Convert.ToInt32(cantidad) + 1;
            foreach (DataRow drw in datatable.Rows)
            {
                if (drw["IdProducto"].ToString() == item)
                {
                    drw["Cantidad"] = cant;
                    drw["SubTotal"] = cant * Convert.ToDecimal(drw["Precio"].ToString());
                }
            }
            Response.Redirect("Carrito.aspx");
        }
        private void restar(string cantidad, string idproducto)
        {
            DataTable datatable = (DataTable)Session["ListaCarrito"];
            int cant = Convert.ToInt32(cantidad) - 1;
            if (cant < 1)
            {
                foreach (DataRow drw in datatable.Rows)
                {
                    if (drw["IdProducto"].ToString() == idproducto)
                    {
                        drw["Cantidad"] = 1;
                        drw["SubTotal"] = Convert.ToDecimal(drw["Precio"].ToString());
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
            else
            {
                foreach (DataRow drw in datatable.Rows)
                {
                    if (drw["IdProducto"].ToString() == idproducto)
                    {
                        drw["Cantidad"] = cant;
                        drw["SubTotal"] = cant * Convert.ToDecimal(drw["Precio"].ToString());
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
        }
        private void deleteitem(string idproducto)
        {
            int fila = 0;
            DataTable datatable = (DataTable)Session["ListaCarrito"];
            GridView gridview = new GridView();
            gridview.DataSource = datatable;
            gridview.DataBind();
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                if (gridview.Rows[i].Cells[0].Text == idproducto)
                {
                    fila = i;
                }
            }
            datatable.Rows[fila].Delete();
            CarritoCompras.DataSource = datatable;
            CarritoCompras.DataBind();
            Session["ListaCarrito"] = datatable;
            Session["Item"] = Convert.ToString(datatable.Rows.Count);
            Response.Redirect("Carrito.aspx");
        }
        protected void btnpedido_Click(object sender, EventArgs e)
        {
            if (Session["ListaCarrito"] != null)
            {
                DataTable datatable = (DataTable)Session["ListaCarrito"];
                if (datatable.Rows.Count != 0)
                {
                    if (Session["UserSession"] != null)
                    {
                        Response.Redirect("MiPedido.aspx");
                    }
                    else
                    {
                        Response.Redirect("Acces/Login.aspx");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "errorpedido()", true);
                }
            }
            else
            {
                Response.Redirect("Principal.aspx");
            }
        }
    }
}