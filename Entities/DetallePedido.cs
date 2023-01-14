namespace Entities
{
    public class DetallePedido
    {
        public long CodPedido { set; get; }
        public long IdProducto { set; get; }
        public decimal Precio { set; get; }
        public long cantidad { set; get; }
        public decimal SubTotal { set; get; }
        public decimal TotalPagar { set; get; }
    }
}
