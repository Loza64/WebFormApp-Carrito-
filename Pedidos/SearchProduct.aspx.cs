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
    public partial class SearchProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ListProducts.DataSource = (List<Producto>)Session["SearchProduct"];
                    ListProducts.DataBind();
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
                                Imagen = "data:image/jpg;base64," + Convert.ToBase64String(product.Imagen),
                                Nombre = product.Nombre,
                                Precio = product.Precio,
                                Cantidad = 1,
                                SubTotal = product.Precio,
                                Total = (double)Math.Round((product.Precio * 0.13) + product.Precio, 2, MidpointRounding.AwayFromZero)
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
                            Imagen = "data:image/jpg;base64," + Convert.ToBase64String(product.Imagen),
                            Nombre = product.Nombre,
                            Precio = product.Precio,
                            Cantidad = 1,
                            SubTotal = product.Precio,
                            Total = (double)Math.Round((product.Precio * 0.13) + product.Precio, 2, MidpointRounding.AwayFromZero)
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
            Response.Redirect("/SearchProduct");
        }

        protected void ListProductsCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "detalles")
            {
                Label lblid = (Label)e.Item.FindControl("lblid");
                Session["Producto"] = ProductoLN.GetInstance().GetProduct(Convert.ToInt64(lblid.Text));
                Response.Redirect("DetalleProducto");
            }
        }

        protected void ListProductsDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            //Obetener estado del producto
            Label estado = (Label)e.Item.FindControl("lblestado");
            if (estado.Text == "Disponible")
            {
                estado.ForeColor = Color.Green;
            }
            else
            {
                estado.ForeColor = Color.Red;
            }

            //Obtener la categoria del producto
            try
            {
                long idCategoria = Convert.ToInt64((e.Item.FindControl("lblidcategoria") as Label).Text);
                long idProducto = Convert.ToInt64((e.Item.FindControl("lblid") as Label).Text);
                ((Label)e.Item.FindControl("lblcategoria")).Text = "Categoria: " + CateogiraLN.GetInstance().GetCategoryName(idCategoria);
                (e.Item.FindControl("imgproducto") as ImageButton).ImageUrl = ProductoLN.GetInstance().GetImgProduct(idProducto);

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