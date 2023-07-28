namespace AirShoesNic01.Models
{
    public class Detalle_del_pedido
    {
        public int id { get; set; }
        public int Costo_unitario { get; set; }
        public int Cantidad { get; set; }
        public int Subtotal { get; set; }

        public int pedidoid { get; set; }
        public Pedido? pedido { get; set; }
    }
}
