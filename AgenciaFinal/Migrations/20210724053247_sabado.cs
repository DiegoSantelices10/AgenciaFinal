using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaFinal.Migrations
{
    public partial class sabado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                schema: "dbo",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "barrio",
                table: "Alojamiento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cantidadDeBanios",
                table: "Alojamiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cantidadDePersonas",
                table: "Alojamiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cantidad_de_habitaciones",
                table: "Alojamiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ciudad",
                table: "Alojamiento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "esHotel",
                table: "Alojamiento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "estrellas",
                table: "Alojamiento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "precio_por_dia",
                table: "Alojamiento",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "precio_por_persona",
                table: "Alojamiento",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "tv",
                table: "Alojamiento",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNI",
                schema: "dbo",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "barrio",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "cantidadDeBanios",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "cantidadDePersonas",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "cantidad_de_habitaciones",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "ciudad",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "esHotel",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "estrellas",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "precio_por_dia",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "precio_por_persona",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "tv",
                table: "Alojamiento");

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Id);
                });
        }
    }
}
