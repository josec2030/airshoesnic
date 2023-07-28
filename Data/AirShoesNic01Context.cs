using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirShoesNic01.Models;

namespace AirShoesNic01.Data
{
    public class AirShoesNic01Context : DbContext
    {
        public AirShoesNic01Context (DbContextOptions<AirShoesNic01Context> options)
            : base(options)
        {
        }

        public DbSet<AirShoesNic01.Models.Administrador> Administrador { get; set; } = default!;

        public DbSet<AirShoesNic01.Models.Carrito_de_compras>? Carrito_de_compras { get; set; }

        public DbSet<AirShoesNic01.Models.Clientes>? Clientes { get; set; }

        public DbSet<AirShoesNic01.Models.Detalle_del_pedido>? Detalle_del_pedido { get; set; }

        public DbSet<AirShoesNic01.Models.Informacion_del_envio>? Informacion_del_envio { get; set; }

        public DbSet<AirShoesNic01.Models.Producto>? Producto { get; set; }

        public DbSet<AirShoesNic01.Models.Usuarios>? Usuarios { get; set; }

        public DbSet<AirShoesNic01.Models.Pedido>? Pedido { get; set; }
    }
}
