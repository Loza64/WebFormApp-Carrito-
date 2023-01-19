using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
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
                try
                {
                    long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("lblidproducto")).Text);
                    (e.Item.FindControl("imgproducto") as System.Web.UI.WebControls.Image).ImageUrl = ProductoLN.GetInstance().GetImgProduct(IdProduct);
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
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (SqlNullValueException ex)
                {
                    throw ex;
                }
                catch (TimeoutException ex)
                {
                    throw ex;
                }
                catch (NullReferenceException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
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
            Response.Redirect("/Carrito");
        }
        private void UpdateCart(List<ListadoCarrito> listadoCarrito)
        {
            carrito.DataSource = listadoCarrito;
            carrito.DataBind();
            decimal SubTotal = 0.00m;
            decimal iva = 0.00m;
            decimal Total = 0.00m;
            if (Session["carrito"] != null)
            {
                SubTotal = listadoCarrito.Sum(item => item.SubTotal);
                iva = Math.Round(SubTotal * 0.13m, 2, MidpointRounding.AwayFromZero);
                Total = listadoCarrito.Sum(item => item.Total);
                txtsubtotal.Text = "US$" + SubTotal.ToString();
                txtiva.Text = "US$" + iva.ToString();
                txttotal.Text = "US$" + Total.ToString();
                Session["SubTotal"] = SubTotal;
                Session["Total"] = Total;
            }
            else
            {
                txtsubtotal.Text = "$0.00";
                txtiva.Text = "$0.00";
                txttotal.Text = "$0.00";
            }
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
                            carrito.Total = Math.Round((carrito.SubTotal * 0.13m) + carrito.SubTotal, 2, MidpointRounding.AwayFromZero);
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
                            carrito.Total = Math.Round((carrito.SubTotal * 0.13m) + carrito.SubTotal, 2, MidpointRounding.AwayFromZero);
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
                        carrito.Total = Math.Round((carrito.SubTotal * 0.13m) + carrito.SubTotal, 2, MidpointRounding.AwayFromZero);
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
                        Response.Redirect("/GenerarPedido");
                    }
                    else
                    {
                        Response.Redirect("Login");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "errorpedido()", true);
                }
            }
            else
            {
                Response.Redirect("/Principal");
            }
        }
    }
}