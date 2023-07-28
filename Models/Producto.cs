namespace AirShoesNic01.Models
{
    public class Producto
    {
        public int id { get; set; }
        public String? Nombre { get; set; }
        public int Precio { get; set; }

        public ICollection<Producto>? Productos { get; set; }
    }
}
