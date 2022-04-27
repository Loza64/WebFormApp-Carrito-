using DBConnect;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class ProductoDAO
    {
        private static ProductoDAO product = null;
        private ProductoDAO() { }
        public static ProductoDAO GetInstance()
        {
            if(product == null)
            {
                product = new ProductoDAO();
            }
            return product;
        }


        public DataTable mostrarproducto()
        {
            DataTable list = new DataTable();
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            SqlDataReader sdr = null;
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "select * from Producto";
                scmd.CommandType = CommandType.Text;
                sdr = scmd.ExecuteReader();
                list.Load(sdr);
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sdr.Close();
            }
            return list;
        }

        public string ImagenProducto(long id)
        {
            string Foto = null;
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            SqlDataReader sdr = null;
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "select Imagen from Producto where Id = @Id";
                scmd.CommandType = CommandType.Text;
                scmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    Foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])sdr["Imagen"]);
                }
            }                                                  
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                sdr.Close();
                con.Close();
                scmd.Parameters.Clear();
            }
            return Foto;
        }

        public Producto seleccionarproducto(long id)
        {
            Producto product = null;
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            SqlDataReader sdr = null;
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "select * from Producto where id = @Id";
                scmd.CommandType = CommandType.Text;
                scmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    product = new Producto();
                    product.Id = Convert.ToInt64(sdr["Id"].ToString());
                    product.Nombre = sdr["Nombre"].ToString();
                    product.Descripcion = sdr["Descripcion"].ToString();
                    product.Imagen = (byte[])sdr["Imagen"];
                    product.Stock = Convert.ToInt32(sdr["Stock"].ToString());
                    product.Precio = (decimal)Convert.ToDouble(sdr["Precio"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sdr.Close();
            }
            return product;
        }

        public DataTable buscarproducto(string nombre)
        {
            DataTable list = new DataTable();
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "select * from Producto where Nombre like '%'+@cmdproducto+'%'";
                scmd.CommandType = CommandType.Text;
                scmd.Parameters.Add("@cmdproducto", SqlDbType.VarChar).Value = nombre;
                SqlDataReader sdr = scmd.ExecuteReader();
                list.Load(sdr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                scmd.Parameters.Clear();
            }
            return list;
        }

        public bool registrarproducto(Producto producto)
        {
            bool responce = false;
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "RegistrarProducto";
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                scmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                scmd.Parameters.AddWithValue("@Imagen", producto.Imagen);
                scmd.Parameters.AddWithValue("@Stock", producto.Stock);
                scmd.Parameters.AddWithValue("@Precio", producto.Precio);
                int upload = scmd.ExecuteNonQuery();
                if(upload != 0)
                {
                    responce = true;
                }
            } catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return responce;
        }

    }
}
