namespace Entities
{
    public class ListadoCarrito
    {
        public long IdProducto { set; get; }
        public string Imagen { set; get; }
        public string Nombre { set; get; }
        public decimal Precio { set; get; }
        public long Cantidad { set; get; }
        public decimal SubTotal { set; get; }
        public decimal Total { set; get; }

        public ListadoCarrito() { }
    }
}
