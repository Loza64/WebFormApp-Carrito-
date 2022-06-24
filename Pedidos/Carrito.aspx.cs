using Logic;
using System;
using System.Data;
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
                UpdateCart();
            }
        }
        protected void CarritoCompras_ItemCommand2(object source, DataListCommandEventArgs e)
        {
            long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("lblidproducto")).Text);
            int cantidad = Convert.ToInt32(((TextBox)e.Item.FindControl("txtcantidad")).Text);
            if (e.CommandName == "Eliminar")
            {
                CarritoCompras.SelectedIndex = e.Item.ItemIndex;
                deleteitem(IdProduct);
            }
            else if (e.CommandName == "sumar")
            {
                CarritoCompras.SelectedIndex = e.Item.ItemIndex;
                sumar(cantidad, IdProduct);

            }
            else if (e.CommandName == "restar")
            {
                CarritoCompras.SelectedIndex = e.Item.ItemIndex;
                restar(cantidad, IdProduct);
            }
        }
        protected void CarritoCompras_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("lblidproducto")).Text);
            int i = 0;
            foreach(DataRow dtr in ((DataTable)Session["ListaCarrito"]).Rows)
            {
                if (dtr["idproducto"].ToString() == Convert.ToString(IdProduct) && ProductoLN.GetInstance().Stock(IdProduct) < 1)
                {
                    ((DataTable)Session["ListaCarrito"]).Rows[i].Delete();
                    Response.Redirect("Carrito.aspx");
                    break;
                }
                i++;
            }
        }
        private void sumar(int cantidad, long IdProduct)
        {
            if (cantidad < Logic.ProductoLN.GetInstance().Stock(IdProduct))
            {
                DataTable datatable = (DataTable)Session["ListaCarrito"];
                int cant = Convert.ToInt32(cantidad) + 1;
                foreach (DataRow drw in datatable.Rows)
                {
                    if (drw["IdProducto"].ToString() == Convert.ToString(IdProduct))
                    {
                        drw["Cantidad"] = cant;
                        drw["SubTotal"] = cant * Convert.ToDecimal(drw["Precio"].ToString());
                        break;
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
            else
            {
                DataTable datatable = (DataTable)Session["ListaCarrito"];
                foreach (DataRow drw in datatable.Rows)
                {
                    if (drw["IdProducto"].ToString() == Convert.ToString(IdProduct))
                    {
                        drw["Cantidad"] = Logic.ProductoLN.GetInstance().Stock(IdProduct);
                        drw["SubTotal"] = Logic.ProductoLN.GetInstance().Stock(IdProduct) * Convert.ToDecimal(drw["Precio"].ToString());
                        break;
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
        }
        private void UpdateCart()
        {
            double SubTotal = 0.00;
            double iva = 0.00;
            double Total = 0.00;
            if (Session["ListaCarrito"] != null)
            {
                foreach (DataRow datarow in ((DataTable)Session["ListaCarrito"]).Rows)
                {
                    SubTotal += Convert.ToDouble(datarow["SubTotal"].ToString());
                    iva = (double)Math.Round(SubTotal * 0.13, 2, MidpointRounding.AwayFromZero);
                    Total = (double)Math.Round(iva + SubTotal, 2, MidpointRounding.AwayFromZero);
                }
                txtsubtotal.Text = "$" + Convert.ToString(SubTotal);
                txtiva.Text = "$" + Convert.ToString(iva);
                txttotal.Text = "$" + Convert.ToString(Total);
                Session["SubTotal"] = (decimal)SubTotal;
                Session["Total"] = (decimal)Total;
            }
            else
            {
                txtsubtotal.Text = "$0.00";
                txtiva.Text = "$0.00";
                txttotal.Text = "$0.00";
            }
            Session["Item"] = Convert.ToString(((DataTable)Session["ListaCarrito"]).Rows.Count);
            CarritoCompras.DataSource = (DataTable)Session["ListaCarrito"];
            CarritoCompras.DataBind();
        }
        private void restar(int cantidad, long IdProduct)
        {
            DataTable datatable = (DataTable)Session["ListaCarrito"];
            int cant = cantidad - 1;
            if (cant < 1)
            {
                foreach (DataRow drw in datatable.Rows)
                {
                    if (drw["IdProducto"].ToString() == Convert.ToString(IdProduct))
                    {
                        drw["Cantidad"] = 1;
                        drw["SubTotal"] = Convert.ToDecimal(drw["Precio"].ToString());
                        break;
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
            else
            {
                foreach (DataRow drw in datatable.Rows)
                {
                    if (drw["IdProducto"].ToString() == Convert.ToString(IdProduct))
                    {
                        drw["Cantidad"] = cant;
                        drw["SubTotal"] = cant * Convert.ToDecimal(drw["Precio"].ToString());
                        break;
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
        }
        private void deleteitem(long IdProduct)
        {
            int i = 0;
            int fila = 0;
            DataTable datatable = (DataTable)Session["ListaCarrito"];
            foreach (DataRow dr in datatable.Rows)
            {
                if (dr[0].ToString() == Convert.ToString(IdProduct))
                {
                    fila = i;
                    break;
                }
                i++;
            }
            datatable.Rows[fila].Delete();
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