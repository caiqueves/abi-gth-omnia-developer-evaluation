using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationEntityUserAndAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_GeolocationId",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "VendaProdutos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutos_ProductId",
                table: "VendaProdutos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_GeolocationId",
                table: "Address",
                column: "GeolocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaProdutos_Product_ProductId",
                table: "VendaProdutos",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaProdutos_Product_ProductId",
                table: "VendaProdutos");

            migrationBuilder.DropIndex(
                name: "IX_VendaProdutos_ProductId",
                table: "VendaProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Address_GeolocationId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "VendaProdutos");

            migrationBuilder.CreateIndex(
                name: "IX_Address_GeolocationId",
                table: "Address",
                column: "GeolocationId",
                unique: true);
        }
    }
}
