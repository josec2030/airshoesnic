namespace AirShoesNic01.Models
{
    public class Administrador
    {
        public int id { get; set; }

        public String? Nombre { get; set; }

        public String? Contraseña { get; set; }

        public ICollection<Usuarios>? Usuarios { get; set; }
    }
}
