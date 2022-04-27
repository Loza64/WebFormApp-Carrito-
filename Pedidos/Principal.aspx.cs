using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pedidos
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ListaCarrito"] == null)
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("Nombre", System.Type.GetType("System.String"));
                    table.Columns.Add("Imagen", System.Type.GetType("System.String"));
                    table.Columns.Add("Descripción", System.Type.GetType("System.String"));
                    table.Columns.Add("Precio", System.Type.GetType("System.Decimal"));
                    table.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
                    table.Columns.Add("SubTotal", System.Type.GetType("System.Decimal"));
                    table.Columns.Add("IdProducto", System.Type.GetType("System.Int64"));
                    table.Columns.Add("Item", System.Type.GetType("System.Int64"));
                    Session["ListaCarrito"] = table;

                }
                listaproductos.DataSource = ProductoLN.GetInstance().mostrarproducto();
                listaproductos.DataBind();
            }
        }

        protected void listaproductos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label txtid = (Label)e.Item.FindControl("txtid");
            Image imgproducto = (Image)e.Item.FindControl("imgproducto");
            string foto = ProductoLN.GetInstance().ImagenProducto(Convert.ToInt64(txtid.Text));
            imgproducto.ImageUrl = foto;
        }

        protected void listaproductos_ItemCommand(object source, DataListCommandEventArgs e)
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

        public void Micarrito(long id)
        {
            int posicion = 0;
            string idproduct = Convert.ToString(id);
            var gridview = new GridView();
            gridview.DataSource = (DataTable)Session["ListaCarrito"];
            gridview.DataBind();
            if (gridview.Rows.Count > 0)
            {
                for (int i = 1; i < gridview.Rows.Count; i++)
                {
                    if (gridview.Rows[i].Cells[6].Text == idproduct)
                    {
                        posicion = i;
                    }
                }

                if (gridview.Rows[posicion].Cells[6].Text == idproduct)
                {
                    int cantidad = Convert.ToInt32(gridview.Rows[posicion].Cells[4].Text) + 1;
                    var carrito = (DataTable)Session["ListaCarrito"];
                    foreach (DataRow drw in carrito.Rows)
                    {
                        if (drw["IdProducto"].ToString() == idproduct)
                        {
                            drw["Cantidad"] = cantidad;
                            drw["SubTotal"] = (decimal)cantidad * Convert.ToDecimal(gridview.Rows[posicion].Cells[3].Text);
                        }
                    }
                }
                else
                {
                    Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(id);
                    if (prodcut != null)
                    {
                        var ListaCarrito = (DataTable)Session["ListaCarrito"];
                        DataRow FilaCarrito = ListaCarrito.NewRow();
                        FilaCarrito[0] = prodcut.Nombre;
                        FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                        FilaCarrito[2] = prodcut.Descripcion;
                        FilaCarrito[3] = (decimal)prodcut.Precio;
                        FilaCarrito[4] = 1;
                        FilaCarrito[5] = prodcut.Precio;
                        FilaCarrito[6] = prodcut.Id;
                        FilaCarrito[7] = (int)ListaCarrito.Rows.Count + 1;
                        ListaCarrito.Rows.Add(FilaCarrito);
                        Session["ListaCarrito"] = ListaCarrito;
                        Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
                        Response.Redirect("Principal.aspx");
                    }
                }

            }
            else
            {
                Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(id);
                if (prodcut != null)
                {
                    var ListaCarrito = (DataTable)Session["ListaCarrito"];
                    DataRow FilaCarrito = ListaCarrito.NewRow();
                    FilaCarrito[0] = prodcut.Nombre;
                    FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                    FilaCarrito[2] = prodcut.Descripcion;
                    FilaCarrito[3] = (decimal)prodcut.Precio;
                    FilaCarrito[4] = 1;
                    FilaCarrito[5] = prodcut.Precio;
                    FilaCarrito[6] = prodcut.Id;
                    FilaCarrito[7] = (int)ListaCarrito.Rows.Count + 1;
                    ListaCarrito.Rows.Add(FilaCarrito);
                    Session["ListaCarrito"] = ListaCarrito;
                    Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
                    Response.Redirect("Principal.aspx");
                }
            }
        }

        public void Comprar(long id)
        {
            int posicion = 0;
            string idproduct = Convert.ToString(id);
            var gridview = new GridView();
            gridview.DataSource = (DataTable)Session["ListaCarrito"];
            gridview.DataBind();
            if (gridview.Rows.Count > 0)
            {
                for (int i = 0; i < gridview.Rows.Count; i++)
                {
                    if (gridview.Rows[i].Cells[6].Text == idproduct)
                    {
                        posicion = i;
                    }
                }

                if (gridview.Rows[posicion].Cells[6].Text == idproduct)
                {
                    int cantidad = Convert.ToInt32(gridview.Rows[posicion].Cells[4].Text) + 1;
                    var datalist = (DataTable)Session["ListaCarrito"];
                    foreach (DataRow drw in datalist.Rows)
                    {
                        if (drw["IdProducto"].ToString() == idproduct)
                        {
                            drw["Cantidad"] = cantidad;
                            drw["SubTotal"] = (decimal)cantidad * Convert.ToDecimal(gridview.Rows[posicion].Cells[3].Text);
                            Response.Redirect("Carrito.aspx");
                        }
                    }
                }
                else
                {
                    Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(id);
                    if (prodcut != null)
                    {
                        var ListaCarrito = (DataTable)Session["ListaCarrito"];
                        DataRow FilaCarrito = ListaCarrito.NewRow();
                        FilaCarrito[0] = prodcut.Nombre;
                        FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                        FilaCarrito[2] = prodcut.Descripcion;
                        FilaCarrito[3] = (decimal)prodcut.Precio;
                        FilaCarrito[4] = 1;
                        FilaCarrito[5] = prodcut.Precio;
                        FilaCarrito[6] = prodcut.Id;
                        FilaCarrito[7] = (int)ListaCarrito.Rows.Count + 1;
                        ListaCarrito.Rows.Add(FilaCarrito);
                        Session["ListaCarrito"] = ListaCarrito;
                        Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
                        Response.Redirect("Carrito.aspx");
                    }
                }

            }
            else
            {
                Producto prodcut = ProductoLN.GetInstance().seleccionarproducto(id);
                if (prodcut != null)
                {
                    var ListaCarrito = (DataTable)Session["ListaCarrito"];
                    DataRow FilaCarrito = ListaCarrito.NewRow();
                    FilaCarrito[0] = prodcut.Nombre;
                    FilaCarrito[1] = "data:image/jpg;base64," + Convert.ToBase64String(prodcut.Imagen);
                    FilaCarrito[2] = prodcut.Descripcion;
                    FilaCarrito[3] = (decimal)prodcut.Precio;
                    FilaCarrito[4] = 1;
                    FilaCarrito[5] = prodcut.Precio;
                    FilaCarrito[6] = prodcut.Id;
                    FilaCarrito[7] = (int)ListaCarrito.Rows.Count + 1;
                    ListaCarrito.Rows.Add(FilaCarrito);
                    Session["ListaCarrito"] = ListaCarrito;
                    Session["Item"] = Convert.ToString(ListaCarrito.Rows.Count);
                    Response.Redirect("Carrito.aspx");
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