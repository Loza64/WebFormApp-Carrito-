namespace Entities
{
    public class ListadoCarrito
    {
        public long IdProducto { set; get; }
        public string Imagen { set; get; }
        public string Nombre { set; get; }
        public double Precio { set; get; }
        public long Cantidad { set; get; }
        public double SubTotal { set; get; }

        public ListadoCarrito() { }
    }
}
