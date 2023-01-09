using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Pedidos
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["carrito"] != null)
            {
                UpdateCart((List<ListadoCarrito>)Session["carrito"]);
            }
        }
        protected void ItemDataBoundCarito(object sender, RepeaterItemEventArgs e)
        {
            /* Si el producto que esta en el carrito ya no esta disponible en stock, 
             lo borrara automaticamente del carrito de compras */
            if (Session["carrito"] != null)
            {
                long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("lblidproducto")).Text);
                List<ListadoCarrito> listadoCarrito = (List<ListadoCarrito>)Session["carrito"];
                if (ProductoLN.GetInstance().Stock(IdProduct) < 1)
                {
                    foreach (ListadoCarrito carrito in listadoCarrito)
                    {
                        if (carrito.IdProducto == IdProduct)
                        {
                            listadoCarrito.Remove(carrito);
                            Response.Redirect("Carrito.aspx");
                            break;
                        }
                    }
                }
            }
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
                    Quantity(cantidad + 1, IdProduct, (List<ListadoCarrito>)Session["carrito"]);
                    break;
                case "Restar":
                    Quantity(cantidad - 1, IdProduct, (List<ListadoCarrito>)Session["carrito"]);
                    break;
            }
            Response.Redirect("Carrito.aspx");
        }
        private void UpdateCart(List<ListadoCarrito> listadoCarrito)
        {
            carrito.DataSource = listadoCarrito;
            carrito.DataBind();
            double SubTotal = 0.00;
            double iva = 0.00;
            double Total = 0.00;
            if (Session["carrito"] != null)
            {
                foreach (ListadoCarrito carrito in listadoCarrito)
                {
                    SubTotal += carrito.SubTotal;
                    iva = (double)Math.Round(SubTotal * 0.13, 2, MidpointRounding.AwayFromZero);
                    Total += carrito.Total;
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
        private void Quantity(int cantidad, long IdProduct, List<ListadoCarrito> listadoCarrito)
        {
            if (cantidad >= 1)
            {
                if (cantidad < Logic.ProductoLN.GetInstance().Stock(IdProduct))
                {
                    foreach (ListadoCarrito carrito in listadoCarrito)
                    {
                        if (carrito.IdProducto == IdProduct)
                        {
                            carrito.Cantidad = cantidad;
                            carrito.SubTotal = cantidad * carrito.Precio;
                            carrito.Total = (double)Math.Round((carrito.SubTotal * 0.13) + carrito.SubTotal, 2, MidpointRounding.AwayFromZero);
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
                            carrito.Total = (double)Math.Round((carrito.SubTotal * 0.13) + carrito.SubTotal, 2, MidpointRounding.AwayFromZero);
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (ListadoCarrito carrito in listadoCarrito)
                {
                    if (carrito.IdProducto == IdProduct)
                    {
                        carrito.Cantidad = 1;
                        carrito.SubTotal = carrito.Precio;
                        carrito.Total = (double)Math.Round((carrito.SubTotal * 0.13) + carrito.SubTotal, 2, MidpointRounding.AwayFromZero);
                        break;
                    }
                }
            }
            Session["carrito"] = listadoCarrito;
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
            Session["carrito"] = listadoCarrito;
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