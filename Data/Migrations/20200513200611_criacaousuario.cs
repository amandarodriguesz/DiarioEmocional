using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiarioEmocional.Data.Migrations
{
    public partial class criacaousuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_PsicoterapeutaID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_AspNetUsers_PacienteId",
                table: "Registros");

            migrationBuilder.DropIndex(
                name: "IX_Registros_PacienteId",
                table: "Registros");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PsicoterapeutaID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Registros");

            migrationBuilder.RenameColumn(
                name: "PsicoterapeutaID",
                table: "AspNetUsers",
                newName: "ImageName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoFile",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFile",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "AspNetUsers",
                newName: "PsicoterapeutaID");

            migrationBuilder.AddColumn<string>(
                name: "PacienteId",
                table: "Registros",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PsicoterapeutaID",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Registros_PacienteId",
                table: "Registros",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PsicoterapeutaID",
                table: "AspNetUsers",
                column: "PsicoterapeutaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_PsicoterapeutaID",
                table: "AspNetUsers",
                column: "PsicoterapeutaID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_AspNetUsers_PacienteId",
                table: "Registros",
                column: "PacienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
