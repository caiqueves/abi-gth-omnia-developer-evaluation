using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEntiesFilial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Filiais_FilialId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Filiais_FilialId1",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_FilialId1",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "FilialId1",
                table: "Vendas");

            migrationBuilder.AlterColumn<Guid>(
                name: "FilialId",
                table: "Vendas",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Filiais_FilialId",
                table: "Vendas",
                column: "FilialId",
                principalTable: "Filiais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Filiais_FilialId",
                table: "Vendas");

            migrationBuilder.AlterColumn<Guid>(
                name: "FilialId",
                table: "Vendas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FilialId1",
                table: "Vendas",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FilialId1",
                table: "Vendas",
                column: "FilialId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Filiais_FilialId",
                table: "Vendas",
                column: "FilialId",
                principalTable: "Filiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Filiais_FilialId1",
                table: "Vendas",
                column: "FilialId1",
                principalTable: "Filiais",
                principalColumn: "Id");
        }
    }
}
