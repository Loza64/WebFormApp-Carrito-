namespace Entities
{
    public class DetallePedido
    {
        public long CodPedido { set; get; }
        public long IdProducto { set; get; }
        public double Precio { set; get; }
        public long cantidad { set; get; }
        public double SubTotal { set; get; }
        public double TotalPagar { set; get; }
    }
}
