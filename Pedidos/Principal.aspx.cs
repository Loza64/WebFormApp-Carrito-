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
                    carritocompras.Columns.Add("Descripción", System.Type.GetType("System.String"));//3
                    carritocompras.Columns.Add("Precio", System.Type.GetType("System.Decimal"));//4
                    carritocompras.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));//5
                    carritocompras.Columns.Add("SubTotal", System.Type.GetType("System.Decimal"));//6
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
            Label txtid = (Label)e.Item.FindControl("txtid");
            Image imgproducto = (Image)e.Item.FindControl("imgproducto");
            string foto = ProductoLN.GetInstance().ImagenProducto(Convert.ToInt64(txtid.Text));
            imgproducto.ImageUrl = foto;
            Label estado = (Label)e.Item.FindControl("lblestado");
            if (ProductoLN.GetInstance().Stock(Convert.ToInt64(txtid.Text)) > 0)
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
            int estado = Convert.ToInt32(((Label)e.Item.FindControl("Stock")).Text);
            if (estado > 0)
            {
                if (e.CommandName == "carrito")
                {
                    listaproductos.SelectedIndex = e.Item.ItemIndex;
                    string cod = ((Label)e.Item.FindControl("txtid")).Text;
                    Micarrito(Convert.ToInt64(cod));
                }
                else if (e.CommandName == "comprar")
                {
                    listaproductos.SelectedIndex = e.Item.ItemIndex;
                    string cod = ((Label)e.Item.FindControl("txtid")).Text;
                    Comprar(Convert.ToInt64(cod));
                }
            }
        }
        public void Micarrito(long id)
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
                    if (dr[0].ToString() == Convert.ToString(id))
                    {
                        posicion = i;
                        break;
                    }
                    i++;
                }

                if (gridview.Rows[posicion].Cells[0].Text == Convert.ToString(id))
                {
                    int cantidad = Convert.ToInt32(gridview.Rows[posicion].Cells[5].Text) + 1;
                    var carrito = (DataTable)Session["ListaCarrito"];
                    if (cantidad < ProductoLN.GetInstance().Stock(id))
                    {
                        foreach (DataRow drw in carrito.Rows)
                        {
                            if (drw["IdProducto"].ToString() == Convert.ToString(id))
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
                            if (drw["IdProducto"].ToString() == Convert.ToString(id))
                            {
                                drw["Cantidad"] = ProductoLN.GetInstance().Stock(id);
                                drw["SubTotal"] = (decimal)ProductoLN.GetInstance().Stock(id) * Convert.ToDecimal(gridview.Rows[posicion].Cells[4].Text);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(id);
                        if (prodcut != null)
                        {
                            var ListaCarrito = (DataTable)Session["ListaCarrito"];
                            DataRow FilaCarrito = ListaCarrito.NewRow();
                            FilaCarrito[0] = prodcut.Id;
                            FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                            FilaCarrito[2] = prodcut.Nombre;
                            FilaCarrito[3] = prodcut.Descripcion;
                            FilaCarrito[4] = (decimal)prodcut.Precio;
                            FilaCarrito[5] = 1;
                            FilaCarrito[6] = prodcut.Precio * 1;
                            ListaCarrito.Rows.Add(FilaCarrito);
                            Session["ListaCarrito"] = ListaCarrito;
                            Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
                            Response.Redirect("Principal.aspx");
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
                    Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(id);
                    if (prodcut != null)
                    {
                        var ListaCarrito = (DataTable)Session["ListaCarrito"];
                        DataRow FilaCarrito = ListaCarrito.NewRow();
                        FilaCarrito[0] = prodcut.Id;
                        FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                        FilaCarrito[2] = prodcut.Nombre;
                        FilaCarrito[3] = prodcut.Descripcion;
                        FilaCarrito[4] = (decimal)prodcut.Precio;
                        FilaCarrito[5] = 1;
                        FilaCarrito[6] = prodcut.Precio * 1;
                        ListaCarrito.Rows.Add(FilaCarrito);
                        Session["ListaCarrito"] = ListaCarrito;
                        Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
                        Response.Redirect("Principal.aspx");
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
        public void Comprar(long id)
        {
            int i = 0;
            int posicion = 0;
            string idproduct = Convert.ToString(id);
            var gridview = new GridView();
            gridview.DataSource = (DataTable)Session["ListaCarrito"];
            gridview.DataBind();
            if (gridview.Rows.Count > 0)
            {
                foreach (DataRow dr in ((DataTable)Session["ListaCarrito"]).Rows)
                {
                    if (dr[0].ToString() == idproduct)
                    {
                        posicion = i;
                        break;
                    }
                    i++;
                }
                if (gridview.Rows[posicion].Cells[0].Text == idproduct)
                {
                    int cantidad = Convert.ToInt32(gridview.Rows[posicion].Cells[5].Text) + 1;
                    var carrito = (DataTable)Session["ListaCarrito"];
                    if (cantidad < ProductoLN.GetInstance().Stock(id))
                    {
                        foreach (DataRow drw in carrito.Rows)
                        {
                            if (drw["IdProducto"].ToString() == Convert.ToString(id))
                            {
                                drw["Cantidad"] = cantidad;
                                drw["SubTotal"] = (decimal)cantidad * Convert.ToDecimal(gridview.Rows[posicion].Cells[4].Text);
                                break;
                            }
                        }
                        Response.Redirect("Carrito.aspx");
                    }
                    else
                    {
                        foreach (DataRow drw in carrito.Rows)
                        {
                            if (drw["IdProducto"].ToString() == Convert.ToString(id))
                            {
                                drw["Cantidad"] = ProductoLN.GetInstance().Stock(id);
                                drw["SubTotal"] = (decimal)ProductoLN.GetInstance().Stock(id) * Convert.ToDecimal(gridview.Rows[posicion].Cells[4].Text);
                                break;
                            }
                        }
                        Response.Redirect("Carrito.aspx");
                    }
                }
                else
                {
                    try
                    {
                        Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(id);
                        if (prodcut != null)
                        {
                            var ListaCarrito = (DataTable)Session["ListaCarrito"];
                            DataRow FilaCarrito = ListaCarrito.NewRow();
                            FilaCarrito[0] = prodcut.Id;
                            FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                            FilaCarrito[2] = prodcut.Nombre;
                            FilaCarrito[3] = prodcut.Descripcion;
                            FilaCarrito[4] = (decimal)prodcut.Precio;
                            FilaCarrito[5] = 1;
                            FilaCarrito[6] = prodcut.Precio * 1;
                            ListaCarrito.Rows.Add(FilaCarrito);
                            Session["ListaCarrito"] = ListaCarrito;
                            Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
                            Response.Redirect("Carrito.aspx");
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
                    Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(id);
                    if (prodcut != null)
                    {
                        var ListaCarrito = (DataTable)Session["ListaCarrito"];
                        DataRow FilaCarrito = ListaCarrito.NewRow();
                        FilaCarrito[0] = prodcut.Id;
                        FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                        FilaCarrito[2] = prodcut.Nombre;
                        FilaCarrito[3] = prodcut.Descripcion;
                        FilaCarrito[4] = (decimal)prodcut.Precio;
                        FilaCarrito[5] = 1;
                        FilaCarrito[6] = prodcut.Precio * 1;
                        ListaCarrito.Rows.Add(FilaCarrito);
                        Session["ListaCarrito"] = ListaCarrito;
                        Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
                        Response.Redirect("Carrito.aspx");
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