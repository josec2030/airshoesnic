namespace AirShoesNic01.Models
{
    public class Clientes
    {
        public int id { get; set; }
        public String? Nombre { get; set; }
        public String? Correo { get; set; }
        public String? direccion { get; set; }
        public String? Info_tarjeta_Credito { get; set; }

        public int idusuarios { get; set; }
        public Usuarios? Usuario { get; set; }

        public ICollection<Carrito_de_compras>? Carrito_De_Compras { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
