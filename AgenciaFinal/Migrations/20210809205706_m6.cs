using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaFinal.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "precio",
                table: "Reserva",
                newName: "Phasta");

            migrationBuilder.AddColumn<float>(
                name: "PDesde",
                table: "Reserva",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PDesde",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "Phasta",
                table: "Reserva",
                newName: "precio");
        }
    }
}
