namespace AirShoesNic01.Models
{
    public class Informacion_del_envio
    {
            public int id { get; set; }
            public String? Tipo_de_Envio { get; set; }
            public String? Estado_de_envio { get; set; }

            public int Pedidoid { get; set; }
            public Pedido? Pedido { get; set; }
    }
}
