using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jcf.Infraestrutura.Migrations
{
    public partial class ProfissionalCPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Enderecos_EnderecoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EnderecoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Profissionals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Profissionals");

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "AspNetUsers",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EnderecoId",
                table: "AspNetUsers",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Enderecos_EnderecoId",
                table: "AspNetUsers",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }
    }
}
