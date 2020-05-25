using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioEmocional.Data.Migrations
{
    public partial class modelando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PsicoterapeutaID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Emocoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    UsuarioInclusao = table.Column<string>(nullable: true),
                    UsuarioAlteracao = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emocoes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Intensidades",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    UsuarioInclusao = table.Column<string>(nullable: true),
                    UsuarioAlteracao = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intensidades", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    UsuarioInclusao = table.Column<string>(nullable: true),
                    UsuarioAlteracao = table.Column<string>(nullable: true),
                    EmocaoID = table.Column<int>(nullable: false),
                    IntendidadeID = table.Column<int>(nullable: false),
                    Situacao = table.Column<string>(nullable: true),
                    Comportamento = table.Column<string>(nullable: true),
                    IntensidadeID = table.Column<int>(nullable: true),
                    PacienteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Registros_Emocoes_EmocaoID",
                        column: x => x.EmocaoID,
                        principalTable: "Emocoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Intensidades_IntensidadeID",
                        column: x => x.IntensidadeID,
                        principalTable: "Intensidades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registros_AspNetUsers_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PsicoterapeutaID",
                table: "AspNetUsers",
                column: "PsicoterapeutaID");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_EmocaoID",
                table: "Registros",
                column: "EmocaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_IntensidadeID",
                table: "Registros",
                column: "IntensidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_PacienteId",
                table: "Registros",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_PsicoterapeutaID",
                table: "AspNetUsers",
                column: "PsicoterapeutaID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_PsicoterapeutaID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Emocoes");

            migrationBuilder.DropTable(
                name: "Intensidades");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PsicoterapeutaID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PsicoterapeutaID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
