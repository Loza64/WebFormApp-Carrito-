using Entities;
using Logic;
using System;
using System.Collections.Generic;
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
        List<ListadoCarrito> listadoCarrito;
        protected void ItemDataBoundCarito(object sender, RepeaterItemEventArgs e)
        {
            long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("lblidproducto")).Text);
            int i = 0;
            foreach (DataRow dtr in ((DataTable)Session["ListaCarrito"]).Rows)
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
        protected void ItemCommanCarrito(object source, RepeaterCommandEventArgs e)
        {
            long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("lblidproducto")).Text);
            int cantidad = Convert.ToInt32(((Label)e.Item.FindControl("txtcantidad")).Text);
            switch (e.CommandName)
            {
                case "Eliminar":
                    DeleteProductFromCart(IdProduct);
                    break;
                case "Sumar":
                    AddQuantity(cantidad, IdProduct);
                    break;
                case "Restar":
                    SubtractQuantity(cantidad, IdProduct);
                    break;
                default:
                    Response.Redirect("Carrito.aspx");
                    break;
            }
        }
        private void UpdateCart()
        {
            double SubTotal = 0.00;
            double iva = 0.00;
            double Total = 0.00;
            listadoCarrito = (List<ListadoCarrito>)Session["carrito"];
            if (Session["carrito"] != null)
            {
                foreach (ListadoCarrito carrito in listadoCarrito)
                {
                    SubTotal += carrito.SubTotal;
                    iva = (double)Math.Round(SubTotal * 0.13, 2, MidpointRounding.AwayFromZero);
                    Total = (double)Math.Round(iva + SubTotal, 2, MidpointRounding.AwayFromZero);
                }
                txtsubtotal.Text = "$" + SubTotal.ToString();
                txtiva.Text = "$" + iva.ToString();
                txttotal.Text = "$" + Total.ToString();
                Session["SubTotal"] = SubTotal;
                Session["Total"] = Total;
            }
            else
            {
                txtsubtotal.Text = "$0.00";
                txtiva.Text = "$0.00";
                txttotal.Text = "$0.00";
            }
            Session["Item"] = listadoCarrito.Count;
            carrito.DataSource = listadoCarrito;
            carrito.DataBind();
        }
        private void AddQuantity(int cantidad, long IdProduct)
        {
            listadoCarrito = (List<ListadoCarrito>)Session["carrito"];
            if (cantidad < Logic.ProductoLN.GetInstance().Stock(IdProduct))
            {
                int cant = Convert.ToInt32(cantidad) + 1;
                foreach (ListadoCarrito carrito in listadoCarrito)
                {
                    if (carrito.IdProducto == IdProduct)
                    {
                        carrito.Cantidad = cant;
                        carrito.SubTotal = cant * carrito.Precio;
                        break;
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
            else
            {
                foreach (ListadoCarrito carrito in listadoCarrito)
                {
                    if (carrito.IdProducto == IdProduct)
                    {
                        carrito.Cantidad = Logic.ProductoLN.GetInstance().Stock(IdProduct);
                        carrito.SubTotal = Logic.ProductoLN.GetInstance().Stock(IdProduct) * carrito.Precio;
                        break;
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
        }
        private void SubtractQuantity(int cantidad, long IdProduct)
        {
            listadoCarrito = (List<ListadoCarrito>)Session["carrito"];
            int cant = cantidad - 1;
            if (cant < 1)
            {
                foreach (ListadoCarrito carrito in listadoCarrito)
                {
                    if (carrito.IdProducto == IdProduct)
                    {
                        carrito.Cantidad = cantidad;
                        carrito.SubTotal = carrito.Precio;
                        break;
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
            else
            {
                foreach (ListadoCarrito carrito in listadoCarrito)
                {
                    if (carrito.IdProducto == IdProduct)
                    {
                        carrito.Cantidad = cant;
                        carrito.SubTotal = cant * carrito.Precio;
                        break;
                    }
                }
                Response.Redirect("Carrito.aspx");
            }
        }
        private void DeleteProductFromCart(long IdProduct)
        {
            listadoCarrito = (List<ListadoCarrito>)Session["carrito"];
            foreach (ListadoCarrito carrito in listadoCarrito)
            {
                if (carrito.IdProducto == IdProduct)
                {
                    listadoCarrito.Remove(carrito);
                    break;
                }
            }
            Session["Item"] = listadoCarrito.Count.ToString();
            Response.Redirect("Carrito.aspx");
        }
        protected void btnpedido_Click(object sender, EventArgs e)
        {
            if (Session["carrito"] != null)
            {
                if (listadoCarrito.Count != 0)
                {
                    if (Session["UserSession"] != null)
                    {
                        Response.Redirect("GenerarPedido.aspx");
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