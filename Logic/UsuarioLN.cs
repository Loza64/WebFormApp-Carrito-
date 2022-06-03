using DataAcces;
using Entities;
using System;
using System.Data.SqlClient;

namespace Logic
{
    public class UsuarioLN
    {
        private static UsuarioLN usuario = null;
        private UsuarioLN() { }
        public static UsuarioLN GetInstance()
        {
            if (usuario == null)
            {
                usuario = new UsuarioLN();
            }
            return usuario;
        }


        public Usuario InciarSesion(string usuario, string contraseña)
        {
            try
            {
                return UsuarioDAO.GetInstance().InciarSesion(usuario, contraseña);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SignUp(Usuario user)
        {
            try
            {
                return UsuarioDAO.GetInstance().SignUp(user);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
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
