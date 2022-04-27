using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public long Id { set; get; }
        public string Username { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Genero { set; get; }
        public string Telefono { set; get; }
        public int Edad { set; get; }
        public string Email { set; get; }
        public string Contraseña { set; get; }

        public Usuario() { }

    }
}
