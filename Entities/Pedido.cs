using System;

namespace Entities
{
    public class Pedido
    {
        public long CodPedido { set; get; }
        public long IdUsuario { set; get; }
        public string NombreCliente { set; get; }
        public string TipoPedido { set; get; }
        public string Direccion { set; get; }
        public DateTime FechaEntrega { set; get; }
        public DateTime HoraEntrega { set; get; }
        public decimal SubTotal { set; get; }
        public decimal PagoTotal { set; get; }
        public string Estado { set; get; }

        public Pedido() { }
    }
}
