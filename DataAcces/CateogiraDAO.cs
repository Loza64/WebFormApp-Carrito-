using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAcces
{
    public class CateogiraDAO : ConnectionDB
    {
        private static CateogiraDAO categoriaDao = null;
        private CateogiraDAO() { }
        public static CateogiraDAO GetInstance()
        {
            if (categoriaDao == null)
            {
                categoriaDao = new CateogiraDAO();
            }
            return categoriaDao;
        }

        SqlConnection con;
        SqlCommand scmd;
        SqlDataReader sdr;

        public List<Categoria> GetCategoryies()
        {
            Categoria categoria;
            List<Categoria> list = new List<Categoria>();
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "select * from Categoria";
                        scmd.CommandType = System.Data.CommandType.Text;
                        sdr = scmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            categoria = new Categoria
                            {
                                Id = sdr.GetInt32(0),
                                Nombre = sdr.GetString(1)
                            };
                            list.Add(categoria);
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
                    return list;
                }
            }
        }
        public string GetCategoryName(long id)
        {
            string Category = null;
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "select * from Categoria where Id = @Id";
                        scmd.CommandType = System.Data.CommandType.Text;
                        scmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                        sdr = scmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            Category = sdr["NombreCategoria"].ToString();
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
                    return Category;
                }
            }
        }

    }
}
