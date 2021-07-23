using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaFinal.Migrations
{
    public partial class migracion2007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esAdmin",
                schema: "dbo",
                table: "Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "esAdmin",
                schema: "dbo",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
