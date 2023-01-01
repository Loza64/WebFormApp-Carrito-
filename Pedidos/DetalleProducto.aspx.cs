using Entities;
using Logic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    Response.Redirect("Principal.aspx");
                }
            }
        }

        protected void btncarrito_Click(object sender, EventArgs e)
        {
            Producto product = (Producto)Session["Producto"];
            AddToCart(product.Id);
            Response.Redirect("DetalleProducto.aspx");
        }

        protected void btnprincipal_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx");
        }

        public void AddToCart(long IdProduct)
        {
            int i = 0;
            int posicion = 0;
            var gridview = new GridView();
            gridview.DataSource = (DataTable)Session["ListaCarrito"];
            gridview.DataBind();
            if (gridview.Rows.Count > 0)
            {
                foreach (DataRow dr in ((DataTable)Session["ListaCarrito"]).Rows)
                {
                    if (dr[0].ToString() == Convert.ToString(IdProduct))
                    {
                        posicion = i;
                        break;
                    }
                    i++;
                }

                if (gridview.Rows[posicion].Cells[0].Text == Convert.ToString(IdProduct))
                {
                    int cantidad = Convert.ToInt32(gridview.Rows[posicion].Cells[4].Text) + 1;
                    var carrito = (DataTable)Session["ListaCarrito"];
                    if (cantidad < ProductoLN.GetInstance().Stock(IdProduct))
                    {
                        foreach (DataRow drw in carrito.Rows)
                        {
                            if (drw["IdProducto"].ToString() == Convert.ToString(IdProduct))
                            {
                                drw["Cantidad"] = cantidad;
                                drw["SubTotal"] = (decimal)cantidad * Convert.ToDecimal(gridview.Rows[posicion].Cells[5].Text);
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow drw in carrito.Rows)
                        {
                            if (drw["IdProducto"].ToString() == Convert.ToString(IdProduct))
                            {
                                drw["Cantidad"] = ProductoLN.GetInstance().Stock(IdProduct);
                                drw["SubTotal"] = (decimal)ProductoLN.GetInstance().Stock(IdProduct) * Convert.ToDecimal(gridview.Rows[posicion].Cells[5].Text);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        Producto prodcut = ProductoLN.GetInstance().GetProduct(IdProduct);
                        if (prodcut != null)
                        {
                            var ListaCarrito = (DataTable)Session["ListaCarrito"];
                            DataRow FilaCarrito = ListaCarrito.NewRow();
                            FilaCarrito[0] = prodcut.Id;
                            FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                            FilaCarrito[2] = prodcut.Nombre;
                            FilaCarrito[3] = (decimal)prodcut.Precio;
                            FilaCarrito[4] = 1;
                            FilaCarrito[5] = prodcut.Precio;
                            ListaCarrito.Rows.Add(FilaCarrito);
                            Session["ListaCarrito"] = ListaCarrito;
                            Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
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
                    Producto prodcut = ProductoLN.GetInstance().GetProduct(IdProduct);
                    if (prodcut != null)
                    {
                        var ListaCarrito = (DataTable)Session["ListaCarrito"];
                        DataRow FilaCarrito = ListaCarrito.NewRow();
                        FilaCarrito[0] = prodcut.Id;
                        FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                        FilaCarrito[2] = prodcut.Nombre;
                        FilaCarrito[3] = (decimal)prodcut.Precio;
                        FilaCarrito[4] = 1;
                        FilaCarrito[5] = prodcut.Precio;
                        ListaCarrito.Rows.Add(FilaCarrito);
                        Session["ListaCarrito"] = ListaCarrito;
                        Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
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


    }
}