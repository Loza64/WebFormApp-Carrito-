namespace Entities
{
    public class Producto
    {
        public long Id { set; get; }
        public long IdCategoria { set; get; }
        public string Nombre { set; get; }
        public byte[] Imagen { set; get; }
        public string Detalle { set; get; }
        public string Company { set; get; }
        public int Stock { set; get; }
        public double Precio { set; get; }
        public string Estado { set; get; }
        public Producto() { }
    }
}
