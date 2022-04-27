using DataAcces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
