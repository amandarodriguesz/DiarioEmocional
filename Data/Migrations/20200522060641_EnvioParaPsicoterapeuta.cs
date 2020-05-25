using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioEmocional.Data.Migrations
{
    public partial class EnvioParaPsicoterapeuta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<bool>(
                name: "EnviarPsicoterapeuta",
                table: "Registros",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LidoPsicoterapeuta",
                table: "Registros",
                nullable: false,
                defaultValue: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnviarPsicoterapeuta",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "LidoPsicoterapeuta",
                table: "Registros");

        }
    }
}
