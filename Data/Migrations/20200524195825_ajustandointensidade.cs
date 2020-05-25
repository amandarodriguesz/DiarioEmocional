using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioEmocional.Data.Migrations
{
    public partial class ajustandointensidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Intensidades_IntensidadeID",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "IntendidadeID",
                table: "Registros");

            migrationBuilder.AlterColumn<int>(
                name: "IntensidadeID",
                table: "Registros",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Intensidades_IntensidadeID",
                table: "Registros",
                column: "IntensidadeID",
                principalTable: "Intensidades",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Intensidades_IntensidadeID",
                table: "Registros");

            migrationBuilder.AlterColumn<int>(
                name: "IntensidadeID",
                table: "Registros",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IntendidadeID",
                table: "Registros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Intensidades_IntensidadeID",
                table: "Registros",
                column: "IntensidadeID",
                principalTable: "Intensidades",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
