using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddPropriedadesVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "tbVendaItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "tbVendaItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "tbVendaItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "tbVenda",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVenda",
                table: "tbVenda",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NumeroVenda",
                table: "tbVenda",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "tbVenda",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "tbVenda",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_tbVendaItem_ProdutoId",
                table: "tbVendaItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVenda_ClienteId",
                table: "tbVenda",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbVenda_tbCliente_ClienteId",
                table: "tbVenda",
                column: "ClienteId",
                principalTable: "tbCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbVendaItem_tbProduto_ProdutoId",
                table: "tbVendaItem",
                column: "ProdutoId",
                principalTable: "tbProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbVenda_tbCliente_ClienteId",
                table: "tbVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_tbVendaItem_tbProduto_ProdutoId",
                table: "tbVendaItem");

            migrationBuilder.DropIndex(
                name: "IX_tbVendaItem_ProdutoId",
                table: "tbVendaItem");

            migrationBuilder.DropIndex(
                name: "IX_tbVenda_ClienteId",
                table: "tbVenda");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "tbVendaItem");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "tbVendaItem");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "tbVendaItem");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "tbVenda");

            migrationBuilder.DropColumn(
                name: "DataVenda",
                table: "tbVenda");

            migrationBuilder.DropColumn(
                name: "NumeroVenda",
                table: "tbVenda");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "tbVenda");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "tbVenda");
        }
    }
}
