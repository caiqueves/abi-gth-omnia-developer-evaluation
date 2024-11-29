using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTableContextCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_GeolocationId",
                table: "Address");

            migrationBuilder.CreateTable(
                name: "Filiais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    DataVenda = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Cancelado = table.Column<bool>(type: "boolean", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    FilialId = table.Column<Guid>(type: "uuid", nullable: false),
                    FilialId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Filiais_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Filiais_FilialId1",
                        column: x => x.FilialId1,
                        principalTable: "Filiais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vendas_Users_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendaProdutos",
                columns: table => new
                {
                    VendaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaProdutos", x => new { x.VendaId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_VendaProdutos_Product_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendaProdutos_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_GeolocationId",
                table: "Address",
                column: "GeolocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutos_ProdutoId",
                table: "VendaProdutos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FilialId",
                table: "Vendas",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FilialId1",
                table: "Vendas",
                column: "FilialId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaProdutos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Filiais");

            migrationBuilder.DropIndex(
                name: "IX_Address_GeolocationId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_GeolocationId",
                table: "Address",
                column: "GeolocationId");
        }
    }
}
