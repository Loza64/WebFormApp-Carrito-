using Entities;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System;

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
        public string GetCategory(long id)
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
                        SqlDataReader sdr = scmd.ExecuteReader();
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
