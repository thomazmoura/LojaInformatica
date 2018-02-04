using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LojaInformatica.API.Dados.Migrations
{
    public partial class ReestruturacaoDeImagensEProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagem_Produtos_ProdutoId",
                table: "Imagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Imagem_ImagemPrincipalId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ImagemPrincipalId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ImagemPrincipalId",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Imagem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ImagemPrincipal",
                table: "Imagem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagem_Produtos_ProdutoId",
                table: "Imagem",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagem_Produtos_ProdutoId",
                table: "Imagem");

            migrationBuilder.DropColumn(
                name: "ImagemPrincipal",
                table: "Imagem");

            migrationBuilder.AddColumn<int>(
                name: "ImagemPrincipalId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Imagem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ImagemPrincipalId",
                table: "Produtos",
                column: "ImagemPrincipalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagem_Produtos_ProdutoId",
                table: "Imagem",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Imagem_ImagemPrincipalId",
                table: "Produtos",
                column: "ImagemPrincipalId",
                principalTable: "Imagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
