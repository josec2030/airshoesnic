namespace AirShoesNic01.Models
{
    public class Carrito_de_compras
    {
        public int id { get; set; }
        public DateTime Fecha_de_entrega { get; set; }
        public String? Direccion { get; set; }
        public int Cantidad { get; set; }


        public int Clienteid { get; set; }
        public Clientes? clientes { get; set; }
    }
}
