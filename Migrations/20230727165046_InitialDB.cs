using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirShoesNic01.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Productoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Producto_Producto_Productoid",
                        column: x => x.Productoid,
                        principalTable: "Producto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contraseña = table.Column<int>(type: "int", nullable: false),
                    administradorid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Administrador_administradorid",
                        column: x => x.administradorid,
                        principalTable: "Administrador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_tarjeta_Credito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idusuarios = table.Column<int>(type: "int", nullable: false),
                    Usuarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Carrito_de_compras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_de_entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Clienteid = table.Column<int>(type: "int", nullable: false),
                    clientesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito_de_compras", x => x.id);
                    table.ForeignKey(
                        name: "FK_Carrito_de_compras_Clientes_clientesid",
                        column: x => x.clientesid,
                        principalTable: "Clientes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_de_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_de_envio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado_del_pedido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clienteid = table.Column<int>(type: "int", nullable: false),
                    productoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Producto_productoid",
                        column: x => x.productoid,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_del_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Costo_unitario = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<int>(type: "int", nullable: false),
                    pedidoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_del_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Detalle_del_pedido_Pedido_pedidoid",
                        column: x => x.pedidoid,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Informacion_del_envio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_de_Envio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado_de_envio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pedidoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informacion_del_envio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Informacion_del_envio_Pedido_Pedidoid",
                        column: x => x.Pedidoid,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_de_compras_clientesid",
                table: "Carrito_de_compras",
                column: "clientesid");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Usuarioid",
                table: "Clientes",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_del_pedido_pedidoid",
                table: "Detalle_del_pedido",
                column: "pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_Informacion_del_envio_Pedidoid",
                table: "Informacion_del_envio",
                column: "Pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_clienteid",
                table: "Pedido",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_productoid",
                table: "Pedido",
                column: "productoid");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Productoid",
                table: "Producto",
                column: "Productoid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_administradorid",
                table: "Usuarios",
                column: "administradorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito_de_compras");

            migrationBuilder.DropTable(
                name: "Detalle_del_pedido");

            migrationBuilder.DropTable(
                name: "Informacion_del_envio");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Administrador");
        }
    }
}
