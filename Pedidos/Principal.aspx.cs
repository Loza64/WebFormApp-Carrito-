using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pedidos
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["carrito"] == null)
                {
                    Session["carrito"] = new List<ListadoCarrito>();
                }
                try
                {
                    Repeater1.DataSource = ProductoLN.GetInstance().ShowProducts();
                    Repeater1.DataBind();
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
                                Imagen = ProductoLN.GetInstance().GetImgProduct(product.Id),
                                Nombre = product.Detalle,
                                Precio = product.Precio,
                                Cantidad = 1,
                                SubTotal = product.Precio
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
                            Imagen = ProductoLN.GetInstance().GetImgProduct(product.Id),
                            Nombre = product.Detalle,
                            Precio = product.Precio,
                            Cantidad = 1,
                            SubTotal = product.Precio
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
            Session["Item"] = listadoCarrito.Count.ToString();
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbuscar.Text))
            {

                Repeater1.DataSource = ProductoLN.GetInstance().SearchProduct(txtbuscar.Text);
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = ProductoLN.GetInstance().ShowProducts();
                Repeater1.DataBind();
            }
        }

        protected void RepeaterCommand(object source, RepeaterCommandEventArgs e)
        {
            int Stock = Convert.ToInt32(((Label)e.Item.FindControl("Stock")).Text);
            long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("txtid")).Text);
            if (Stock > 0)
            {
                if (e.CommandName == "carrito")
                {
                    AddToCart(IdProduct);
                    Response.Redirect("Principal.aspx");
                }
                else if (e.CommandName == "detalle")
                {
                    Producto product = ProductoLN.GetInstance().GetProduct(IdProduct);
                    Session["Producto"] = product;
                    Response.Redirect("DetalleProducto.aspx");
                }
            }
        }

        protected void RepeaterDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label estado = (Label)e.Item.FindControl("lblestado");
            if (ProductoLN.GetInstance().Stock(Convert.ToInt64(((Label)e.Item.FindControl("txtid")).Text)) > 0)
            {
                estado.Text = "Disponible";
                estado.ForeColor = System.Drawing.Color.GreenYellow;
            }
            else
            {
                estado.Text = "No disponible";
                estado.ForeColor = System.Drawing.Color.Red;
            }
            long Stock = Convert.ToInt64(((Label)e.Item.FindControl("Stock")).Text);
            if (Stock > 9999)
            {
                ((Label)e.Item.FindControl("Stock")).Text = "+9999";
            }
        }
    }
}