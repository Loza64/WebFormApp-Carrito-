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
    public class UsuarioDAO
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


        public Usuario InciarSesion(string usuario, string contraseña)
        {
            Usuario user = null;
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "select * from Usuario where (Usuario = @Usuario or Email = @Email) and Contraseña = @Contraseña";
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return user;
        }

        public bool SignUp(Usuario user)
        {
            bool responce = false;
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "insert into Usuario (Usuario,Nombres,Apellidos,Genero,Telefono,Edad,Email,Contraseña) values (@Usuario,@Nombres,@Apellidos,@Genero,@Telefono,@Edad,@Email,@Contraseña)";
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
            catch (Exception ex)
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
