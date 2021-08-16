using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaFinal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Cabania",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    habitaciones = table.Column<int>(type: "int", nullable: false),
                    banios = table.Column<int>(type: "int", nullable: false),
                    precioPorDia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabania", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio_por_persona = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    intentosDeLogueos = table.Column<int>(type: "int", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    esAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Alojamiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    barrio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estrellas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tv = table.Column<bool>(type: "bit", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    esHotel = table.Column<bool>(type: "bit", nullable: false),
                    cantidadDePersonas = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hotelid = table.Column<int>(type: "int", nullable: true),
                    cabaniaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alojamiento_Cabania_cabaniaid",
                        column: x => x.cabaniaid,
                        principalTable: "Cabania",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alojamiento_Hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "Hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agencia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_alojamientoid = table.Column<int>(type: "int", nullable: true),
                    cantAlojamientos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencia", x => x.id);
                    table.ForeignKey(
                        name: "FK_Agencia_Alojamiento_id_alojamientoid",
                        column: x => x.id_alojamientoid,
                        principalTable: "Alojamiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fHasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_alojamientoid = table.Column<int>(type: "int", nullable: true),
                    id_usuarioid = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reserva_Alojamiento_id_alojamientoid",
                        column: x => x.id_alojamientoid,
                        principalTable: "Alojamiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuario_id_usuarioid",
                        column: x => x.id_usuarioid,
                        principalSchema: "dbo",
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencia_id_alojamientoid",
                table: "Agencia",
                column: "id_alojamientoid");

            migrationBuilder.CreateIndex(
                name: "IX_Alojamiento_cabaniaid",
                table: "Alojamiento",
                column: "cabaniaid");

            migrationBuilder.CreateIndex(
                name: "IX_Alojamiento_hotelid",
                table: "Alojamiento",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_id_alojamientoid",
                table: "Reserva",
                column: "id_alojamientoid");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_id_usuarioid",
                table: "Reserva",
                column: "id_usuarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencia");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Alojamiento");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cabania");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
