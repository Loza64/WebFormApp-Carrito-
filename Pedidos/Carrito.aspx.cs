using Entities;
using Logic;
using System;
using System.Collections.Generic;
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
                if (Session["carrito"] != null)
                {
                    UpdateCart((List<ListadoCarrito>)Session["carrito"]);
                }
            }
        }
        protected void ItemDataBoundCarito(object sender, RepeaterItemEventArgs e)
        {
            long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("lblidproducto")).Text);
            List<ListadoCarrito> listadoCarrito = (List<ListadoCarrito>)Session["carrito"];
            if(ProductoLN.GetInstance().Stock(IdProduct) < 1)
            {
                foreach (ListadoCarrito carrito in listadoCarrito)
                {
                    if(carrito.IdProducto == IdProduct)
                    {
                        listadoCarrito.Remove(carrito); 
                    }
                }
            }
            Session["carrito"] = listadoCarrito;
        }
        protected void ItemCommanCarrito(object source, RepeaterCommandEventArgs e)
        {
            long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("lblidproducto")).Text);
            int cantidad = Convert.ToInt32(((Label)e.Item.FindControl("txtcantidad")).Text);
            switch (e.CommandName)
            {
                case "Eliminar":
                    DeleteProductFromCart(IdProduct, (List<ListadoCarrito>)Session["carrito"]);
                    break;
                case "Sumar":
                    AddQuantity(cantidad, IdProduct, (List<ListadoCarrito>)Session["carrito"]);
                    break;
                case "Restar":
                    SubtractQuantity(cantidad, IdProduct, (List<ListadoCarrito>)Session["carrito"]);
                    break;
                default:
                    Response.Redirect("Carrito.aspx");
                    break;
            }
        }
        private void UpdateCart(List<ListadoCarrito> listadoCarrito)
        {
            double SubTotal = 0.00;
            double iva = 0.00;
            double Total = 0.00;
            carrito.DataSource = listadoCarrito;
            carrito.DataBind();
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
            Session["Item"] = listadoCarrito.Count.ToString();
        }
        private void AddQuantity(int cantidad, long IdProduct, List<ListadoCarrito> listadoCarrito)
        {
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
            }
            Session["carrito"] = listadoCarrito;
            Response.Redirect("Carrito.aspx");
        }
        private void SubtractQuantity(int cantidad, long IdProduct, List<ListadoCarrito> listadoCarrito)
        {
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
            }
            Response.Redirect("Carrito.aspx");
            Response.Redirect("Carrito.aspx");
        }
        private void DeleteProductFromCart(long IdProduct, List<ListadoCarrito> listadoCarrito)
        {
            foreach (ListadoCarrito carrito in listadoCarrito)
            {
                if (carrito.IdProducto == IdProduct)
                {
                    listadoCarrito.Remove(carrito);
                    break;
                }
            }
            Response.Redirect("Carrito.aspx");
            Session["Item"] = listadoCarrito.Count.ToString();
            Response.Redirect("Carrito.aspx");
        }
        protected void btnpedido_Click(object sender, EventArgs e)
        {
            if (Session["carrito"] != null)
            {
                if (((List<ListadoCarrito>)Session["carrito"]).Count != 0)
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