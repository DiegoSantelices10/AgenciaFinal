using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaFinal.Migrations
{
    public partial class migracionLunes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Cliente");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Cliente",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "CorreoElectronico",
                schema: "dbo",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Cliente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "esAdmin",
                schema: "dbo",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "dbo",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "esAdmin",
                schema: "dbo",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                schema: "dbo",
                newName: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "CorreoElectronico",
                table: "Cliente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
