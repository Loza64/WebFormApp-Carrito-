using Entities;
using Logic;
using System;
using System.Drawing;

namespace Pedidos
{
    public partial class registrarproducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Producto getEntities()
        {
            Producto producto = new Producto();
            producto.Nombre = txtnombre.Text;
            producto.Descripcion = txtdescripcion.Text;
            producto.Stock = Convert.ToInt32(txtstock.Text);
            producto.Imagen = archivo.FileBytes;
            producto.Precio = Convert.ToDecimal(txtprecio.Text);
            return producto;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtdescripcion.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtprecio.Text) || string.IsNullOrEmpty(txtstock.Text) || string.IsNullOrWhiteSpace(archivo.FileName))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "errorproducto()", true);
            }
            else if (!validarprecio(txtprecio.Text))
            {
                txtprecio.Text = "Precio no valido";
            }
            else if (!validarstock(txtstock.Text))
            {
                txtstock.Text = "Numero de stock no valido";
            }
            else
            {
                Bitmap bitmap = new Bitmap(archivo.PostedFile.InputStream);
                Producto product = getEntities();
                bool responce = ProductoLN.GetInstance().registrarproducto(product);
                if (responce == true)
                {
                    Response.Redirect("Principal.aspx");
                }

            }
        }

        public bool validarprecio(string precio)
        {
            bool responce = false;
            try
            {
                decimal price = Convert.ToDecimal(precio);
                responce = true;
            }
            catch (Exception)
            {
                responce = false;
            }
            return responce;
        }

        public bool validarstock(string stock)
        {
            bool responce = false;
            try
            {
                int price = Convert.ToInt32(stock);
                responce = true;
            }
            catch (Exception)
            {
                responce = false;
            }
            return responce;
        }

    }
}