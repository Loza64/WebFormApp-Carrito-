using Entities;
using Logic;
using System;
using System.Data;
using System.Data.SqlClient;
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
                if (Session["ListaCarrito"] == null)
                {
                    DataTable carritocompras = new DataTable();
                    carritocompras.Columns.Add("IdProducto", System.Type.GetType("System.Int64"));//0
                    carritocompras.Columns.Add("Imagen", System.Type.GetType("System.String"));//1
                    carritocompras.Columns.Add("Nombre", System.Type.GetType("System.String"));//2
                    carritocompras.Columns.Add("Precio", System.Type.GetType("System.Decimal"));//3
                    carritocompras.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));//4
                    carritocompras.Columns.Add("SubTotal", System.Type.GetType("System.Decimal"));//5
                    Session["ListaCarrito"] = carritocompras;
                }
                try
                {
                    listaproductos.DataSource = ProductoLN.GetInstance().mostrarproducto();
                    listaproductos.DataBind();
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
        protected void listaproductos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Image imgproducto = (Image)e.Item.FindControl("imgproducto");
            string foto = ProductoLN.GetInstance().ImagenProducto(Convert.ToInt64(((Label)e.Item.FindControl("txtid")).Text));
            imgproducto.ImageUrl = foto;
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
        protected void listaproductos_ItemCommand(object source, DataListCommandEventArgs e)
        {
            listaproductos.SelectedIndex = e.Item.ItemIndex;
            int Stock = Convert.ToInt32(((Label)e.Item.FindControl("Stock")).Text);
            long IdProduct = Convert.ToInt64(((Label)e.Item.FindControl("txtid")).Text);
            if (Stock > 0)
            {
                if (e.CommandName == "carrito")
                {
                    AddToCart(Convert.ToInt64(IdProduct));
                    Response.Redirect("Principal.aspx");
                }
                else if (e.CommandName == "comprar")
                {
                    AddToCart(Convert.ToInt64(IdProduct));
                    Response.Redirect("Carrito.aspx");
                }
            }
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
                    int cantidad = Convert.ToInt32(gridview.Rows[posicion].Cells[5].Text) + 1;
                    var carrito = (DataTable)Session["ListaCarrito"];
                    if (cantidad < ProductoLN.GetInstance().Stock(IdProduct))
                    {
                        foreach (DataRow drw in carrito.Rows)
                        {
                            if (drw["IdProducto"].ToString() == Convert.ToString(IdProduct))
                            {
                                drw["Cantidad"] = cantidad;
                                drw["SubTotal"] = (decimal)cantidad * Convert.ToDecimal(gridview.Rows[posicion].Cells[4].Text);
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
                                drw["SubTotal"] = (decimal)ProductoLN.GetInstance().Stock(IdProduct) * Convert.ToDecimal(gridview.Rows[posicion].Cells[4].Text);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(IdProduct);
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
                    Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(IdProduct);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbuscar.Text))
            {
                listaproductos.DataSource = ProductoLN.GetInstance().buscarproducto(txtbuscar.Text);
                listaproductos.DataBind();
            }
            else
            {
                listaproductos.DataSource = ProductoLN.GetInstance().mostrarproducto();
                listaproductos.DataBind();
            }
        }
    }
}