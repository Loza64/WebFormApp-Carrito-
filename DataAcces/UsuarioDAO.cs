using Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAcces
{
    public class UsuarioDAO : ConnectionDB
    {
        private static UsuarioDAO usuario = null;
        private UsuarioDAO() { }
        public static UsuarioDAO GetInstance()
        {
            if (usuario == null)
            {
                usuario = new UsuarioDAO();
            }
            return usuario;
        }

        SqlConnection con = null;
        SqlCommand scmd = null;

        public Usuario Login(string usuario, string password)
        {
            Usuario user = null;
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "select * from Usuario where (Usuario = @Usuario or Email = @Email) and Convert(nvarchar(max),DECRYPTBYPASSPHRASE('SystemPedidosDBPasswordSecurity',Password)) = @Password";
                        scmd.CommandType = System.Data.CommandType.Text;
                        scmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
                        scmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = usuario;
                        scmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = password;
                        SqlDataReader sdr = scmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            user = new Usuario
                            {
                                Id = sdr.GetInt64(0),
                                Username = sdr.GetString(1),
                                Nombres = sdr.GetString(2),
                                Apellidos = sdr.GetString(3),
                                Genero = sdr.GetString(4),
                                Edad = sdr.GetInt32(5),
                                Email = sdr.GetString(6),
                                Telefono = sdr.GetString(7)
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
            return user;
        }

        public bool CheckUserData(string usuario, string email,string telefono)
        {
            bool check = false;
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "select * from Usuario where Usuario = @Usuario or Email = @Email or Telefono = @Telefono";
                        scmd.CommandType = System.Data.CommandType.Text;
                        scmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
                        scmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = email;
                        scmd.Parameters.AddWithValue("@Telefono", SqlDbType.NVarChar).Value = telefono;
                        SqlDataReader sdr = scmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            check = true;
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
            return check;
        }

        public bool SignUp(Usuario user)
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
                        scmd.CommandText = "insert into Usuario (Usuario,Nombres,Apellidos,Genero,Telefono,Edad,Email,Password) values (@Usuario,@Nombres,@Apellidos,@Genero,@Telefono,@Edad,@Email,ENCRYPTBYPASSPHRASE('SystemPedidosDBPasswordSecurity',@Password))";
                        scmd.CommandType = System.Data.CommandType.Text;
                        scmd.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar).Value = user.Username;
                        scmd.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = user.Nombres;
                        scmd.Parameters.AddWithValue("@Apellidos", SqlDbType.VarChar).Value = user.Apellidos;
                        scmd.Parameters.AddWithValue("@Genero", SqlDbType.VarChar).Value = user.Genero;
                        scmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = user.Telefono;
                        scmd.Parameters.AddWithValue("@Edad", SqlDbType.Int).Value = user.Edad;
                        scmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = user.Email;
                        scmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = user.Password;
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
    }
}
