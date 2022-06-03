using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DetallePedido
    {
        public long CodPedido { set; get; }
        public long IdProducto { set; get; }
        public decimal Precio { set; get; }
        public int cantidad { set; get; }
        public decimal SubTotal { set; get; }
        public decimal TotalPagar { set; get; }
    }
}
