using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Web.UI.WebControls;

namespace Pedidos
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Productslist.DataSource = ProductoLN.GetInstance().ShowProducts();
                    Productslist.DataBind();
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

        public void AddToCart(long IdProduct)
        {
            bool checkProduct = false;
            Producto product;
            List<ListadoCarrito> listadoCarrito = (List<ListadoCarrito>)Session["carrito"];

            //Si el carrito no esta vacio realizara el proceso a continuación caso contrario solo agregara un nuevo producto al carrito
            if (listadoCarrito.Count > 0)
            {
                //Si el producto existe en el carrito solo aumentara la cantidad caso contrario lo agregara al carrito
                foreach (ListadoCarrito cart in listadoCarrito)
                {
                    if (cart.IdProducto == IdProduct)
                    {
                        cart.Cantidad += cart.Cantidad;
                        cart.SubTotal = Math.Round(cart.Precio * cart.Cantidad, 2, MidpointRounding.AwayFromZero);
                        cart.Total = Math.Round((cart.SubTotal + 0.13m) + cart.SubTotal, 2, MidpointRounding.AwayFromZero);
                        checkProduct = true;
                        break;
                    }
                }
                if (!checkProduct)
                {
                    try
                    {
                        product = ProductoLN.GetInstance().GetProduct(IdProduct);
                        if (product != null)
                        {
                            ListadoCarrito carrito = new ListadoCarrito
                            {
                                IdProducto = product.Id,
                                Nombre = product.Nombre,
                                Precio = product.Precio,
                                Cantidad = 1,
                                SubTotal = product.Precio,
                                Total = Math.Round((product.Precio * 0.13m) + product.Precio, 2, MidpointRounding.AwayFromZero)
                            };
                            listadoCarrito.Add(carrito);
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
            else
            {
                try
                {
                    product = ProductoLN.GetInstance().GetProduct(IdProduct);
                    if (product != null)
                    {
                        ListadoCarrito carrito = new ListadoCarrito
                        {
                            IdProducto = product.Id,
                            Nombre = product.Nombre,
                            Precio = product.Precio,
                            Cantidad = 1,
                            SubTotal = product.Precio,
                            Total = Math.Round((product.Precio * 0.13m) + product.Precio, 2, MidpointRounding.AwayFromZero)
                        };
                        listadoCarrito.Add(carrito);
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
            Session["carrito"] = listadoCarrito;
        }

        protected void ProductslistCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int Stock = Convert.ToInt32(((Label)e.Item.FindControl("Stock")).Text);
            long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("txtid")).Text);
            if (Stock > 0)
            {
                if (e.CommandName == "carrito")
                {
                    AddToCart(IdProduct);
                    Response.Redirect("/Products");
                }
                else if (e.CommandName == "detalle")
                {
                    Producto product = ProductoLN.GetInstance().GetProduct(IdProduct);
                    Session["Producto"] = product;
                    Response.Redirect("/DetalleProducto");
                }
            }
        }

        protected void ProductslistDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            Label estado = (Label)e.Item.FindControl("lblestado");
            long Stock = Convert.ToInt64(((Label)e.Item.FindControl("Stock")).Text);
            if (Stock > 9999)
            {
                ((Label)e.Item.FindControl("Stock")).Text = "+9999";
            }

            //Chekear disponibilidad y obtener imagen del producto
            long idproducto = Convert.ToInt64(((Label)e.Item.FindControl("txtid")).Text);
            try
            {
                //Estado del producto
                if (ProductoLN.GetInstance().Stock(Convert.ToInt64(idproducto)) > 0)
                {
                    estado.Text = "Disponible";
                    estado.ForeColor = Color.GreenYellow;
                }
                else
                {
                    estado.Text = "No disponible";
                    estado.ForeColor = Color.Red;
                }

                //Obtener imagen del producto
                (e.Item.FindControl("imgproducto") as System.Web.UI.WebControls.Image).ImageUrl = ProductoLN.GetInstance().GetImgProduct(idproducto);
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
}