using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAcces
{
    public class ProductoDAO : ConnectionDB
    {
        private static ProductoDAO product = null;
        private ProductoDAO() { }
        public static ProductoDAO GetInstance()
        {
            if (product == null)
            {
                product = new ProductoDAO();
            }
            return product;
        }

        List<Producto> list = null;
        SqlConnection con = null;
        SqlCommand scmd = null;
        SqlDataReader sdr = null;

        public List<Producto> ShowProducts()
        {
            Producto product;
            list = new List<Producto>();
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "select top(21) * from Producto";
                        scmd.CommandType = CommandType.Text;
                        sdr = scmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            product = new Producto
                            {
                                Id = sdr.GetInt64(0),
                                IdCategoria = sdr.GetInt64(1),
                                //Imagen = (byte[])sdr["Imagen]
                                Nombre = sdr.GetString(2),
                                Company = sdr.GetString(4),
                                Detalle = sdr.GetString(5),
                                Stock = sdr.GetInt32(6),
                                Precio = sdr.GetDecimal(7),
                                Estado = sdr.GetString(8)
                            };
                            list.Add(product);
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
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return list;
        }

        public Producto GetProduct(long id)
        {
            Producto product = null;
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
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
                            product = new Producto
                            {
                                Id = sdr.GetInt64(0),
                                IdCategoria = sdr.GetInt64(1),
                                //Imagen = (byte[])sdr["Imagen]
                                Nombre = sdr.GetString(2),
                                Company = sdr.GetString(4),
                                Detalle = sdr.GetString(5),
                                Stock = sdr.GetInt32(6),
                                Precio = sdr.GetDecimal(7),
                                Estado = sdr.GetString(8)
                            };
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
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return product;
        }

        public string GetImgProduct(long id)
        {
            string image = null;
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "select Imagen from Producto where id = @Id";
                        scmd.CommandType = CommandType.Text;
                        scmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                        sdr = scmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            image = "data:image/jpg;base64," + Convert.ToBase64String((byte[])sdr["Imagen"]);
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
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return image;
        }

        public List<Producto> SearchProduct(string nombre)
        {
            Producto product;
            list = new List<Producto>();
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "select top(21) * from Producto where Nombre like '%'+@cmdproducto+'%'";
                        scmd.CommandType = CommandType.Text;
                        scmd.Parameters.Add("@cmdproducto", SqlDbType.VarChar).Value = nombre;
                        sdr = scmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            product = new Producto
                            {
                                Id = sdr.GetInt64(0),
                                IdCategoria = sdr.GetInt64(1),
                                //Imagen = (byte[])sdr["Imagen],
                                Nombre = sdr.GetString(2),
                                Company = sdr.GetString(4),
                                Detalle = sdr.GetString(5),
                                Stock = sdr.GetInt32(6),
                                Precio = sdr.GetDecimal(7),
                                Estado = sdr.GetString(8)
                            };
                            list.Add(product);
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
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return list;
        }

        public long GetStockProduct(long id)
        {
            long cantidad = 0;
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "select stock from producto where id = @id";
                        scmd.CommandType = CommandType.Text;
                        scmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        cantidad = Convert.ToInt64(scmd.ExecuteScalar());
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
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return cantidad;
        }

        public void UpdateStock(long Stock, long Id)
        {
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "update producto set Stock = @stock where id = @id";
                        scmd.CommandType = CommandType.Text;
                        scmd.Parameters.Add("@stock", SqlDbType.Int).Value = Stock;
                        scmd.Parameters.Add("@id", SqlDbType.BigInt).Value = Id;
                        scmd.ExecuteNonQuery();
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
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public bool NewProduct(Producto producto)
        {
            bool responce = false;
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "insert into Producto(Nombre,Descripcion,Imagen,Stock,Precio) values(@Nombre,@Descripcion,@Imagen,@Stock,@Precio)";
                        scmd.CommandType = CommandType.Text;
                        scmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = producto.Nombre;
                        scmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = producto.Detalle;
                        scmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = producto.Imagen;
                        scmd.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
                        scmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;
                        int upload = scmd.ExecuteNonQuery();
                        if (upload != 0)
                        {
                            responce = true;
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
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return responce;
        }

        public void UpdateStateProduct(long Id)
        {
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "update Producto set Estado = 'No disponible' where Id = @id";
                        scmd.CommandType = CommandType.Text;
                        scmd.Parameters.Add("@id", SqlDbType.BigInt).Value = Id;
                        scmd.ExecuteNonQuery();
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
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}
