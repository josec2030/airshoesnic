using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirShoesNic01.Migrations
{
    public partial class InitialDBs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Administrador",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Administrador");
        }
    }
}
