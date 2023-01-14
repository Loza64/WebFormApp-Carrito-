using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;

namespace Pedidos
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Producto"] != null)
                {
                    Producto product = (Producto)Session["Producto"];
                    lblstock.Text = Convert.ToString(product.Stock);
                    lblnombreproducto.Text = product.Nombre;
                    lblcompany.Text = product.Company;
                    lbldescripcion.Text = product.Detalle;
                    lblprecio.Text = Convert.ToString(product.Precio);
                    imgproduct.ImageUrl = ProductoLN.GetInstance().GetImgProduct(product.Id);
                }
                else
                {
                    Response.Redirect("/Products");
                }
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
        protected void btncarrito_Click(object sender, EventArgs e)
        {
            Producto product = (Producto)Session["Producto"];
            AddToCart(product.Id);
        }
        protected void btnprincipal_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/Products");
        }
    }
}