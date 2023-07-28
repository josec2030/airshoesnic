namespace AirShoesNic01.Models
{
    public class Usuarios
    {
        public int id { get; set; }

        public int Nombre { get; set; }
        public int Contraseña { get; set; }

        public int administradorid { get; set; }
        public Administrador? administrador { get; set; }

        public ICollection<Clientes>? Clientes { get; set; }
    }
}
