using DataAcces;
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

        public Usuario Login(string usuario, string contraseña)
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
                        scmd.CommandText = "select * from Usuario where (Usuario = @Usuario or Email = @Email) and Convert(varchar(max),DECRYPTBYPASSPHRASE('SystemPedidosDBPasswordSecurity',Contraseña))= @Contraseña";
                        scmd.CommandType = System.Data.CommandType.Text;
                        scmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
                        scmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = usuario;
                        scmd.Parameters.AddWithValue("@Contraseña", SqlDbType.VarChar).Value = contraseña;
                        SqlDataReader sdr = scmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            user = new Usuario();
                            user.Id = Convert.ToInt64(sdr["Id"].ToString());
                            user.Username = sdr["Usuario"].ToString();
                            user.Nombres = sdr["Nombres"].ToString();
                            user.Apellidos = sdr["Apellidos"].ToString();
                            user.Genero = sdr["Genero"].ToString();
                            user.Edad = Convert.ToInt32(sdr["Edad"].ToString());
                            user.Email = sdr["Email"].ToString();
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
                        scmd.CommandText = "insert into Usuario (Usuario,Nombres,Apellidos,Genero,Telefono,Edad,Email,Contraseña) values (@Usuario,@Nombres,@Apellidos,@Genero,@Telefono,@Edad,@Email,ENCRYPTBYPASSPHRASE('SystemPedidosDBPasswordSecurity',@Contraseña))";
                        scmd.CommandType = System.Data.CommandType.Text;
                        scmd.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar).Value = user.Username;
                        scmd.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = user.Nombres;
                        scmd.Parameters.AddWithValue("@Apellidos", SqlDbType.VarChar).Value = user.Apellidos;
                        scmd.Parameters.AddWithValue("@Genero", SqlDbType.VarChar).Value = user.Genero;
                        scmd.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = user.Telefono;
                        scmd.Parameters.AddWithValue("@Edad", SqlDbType.Int).Value = user.Edad;
                        scmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = user.Email;
                        scmd.Parameters.AddWithValue("@Contraseña", SqlDbType.VarChar).Value = user.Contraseña;
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
