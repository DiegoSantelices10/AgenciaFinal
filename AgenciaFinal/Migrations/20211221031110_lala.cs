using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaFinal.Migrations
{
    public partial class lala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ciudad",
                table: "Alojamiento");

            migrationBuilder.AlterColumn<double>(
                name: "precio",
                table: "Reserva",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "ciudadid",
                table: "Alojamiento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alojamiento_ciudadid",
                table: "Alojamiento",
                column: "ciudadid");

            migrationBuilder.AddForeignKey(
                name: "FK_Alojamiento_Ciudades_ciudadid",
                table: "Alojamiento",
                column: "ciudadid",
                principalTable: "Ciudades",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alojamiento_Ciudades_ciudadid",
                table: "Alojamiento");

            migrationBuilder.DropIndex(
                name: "IX_Alojamiento_ciudadid",
                table: "Alojamiento");

            migrationBuilder.DropColumn(
                name: "ciudadid",
                table: "Alojamiento");

            migrationBuilder.AlterColumn<float>(
                name: "precio",
                table: "Reserva",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "ciudad",
                table: "Alojamiento",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
