using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
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