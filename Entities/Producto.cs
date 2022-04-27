using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Producto
    {
        public long Id { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public byte[] Imagen { set; get; }
        public int Stock { set; get; }
        public decimal Precio { set; get; }
        public Producto () { }
    }
}
