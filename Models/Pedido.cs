namespace AirShoesNic01.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public DateTime? fecha_de_creacion { get; set; }
        public DateTime? fecha_de_envio { get; set; }
        public String? Estado_del_pedido { get; set; }

        public int clienteid { get; set; }
        public Clientes? Cliente { get; set; }

        public int productoid { get; set; }
        public Producto? producto { get; set; }

        public ICollection<Informacion_del_envio>? Informacion_Del_Envios { get; set; }
        public ICollection<Detalle_del_pedido>? Detalles_Del_Pedidos { get; set; }
    }
}
