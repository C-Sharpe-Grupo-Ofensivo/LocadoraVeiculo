using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraVeiculo.Infra.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddTBCupom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CupomId",
                table: "TBCliente",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBCupom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParceiroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCupom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCupom_TBParceiro",
                        column: x => x.ParceiroId,
                        principalTable: "TBParceiro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_CupomId",
                table: "TBCliente",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCupom_ParceiroId",
                table: "TBCupom",
                column: "ParceiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCliente_TBCupom_CupomId",
                table: "TBCliente",
                column: "CupomId",
                principalTable: "TBCupom",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCliente_TBCupom_CupomId",
                table: "TBCliente");

            migrationBuilder.DropTable(
                name: "TBCupom");

            migrationBuilder.DropIndex(
                name: "IX_TBCliente_CupomId",
                table: "TBCliente");

            migrationBuilder.DropColumn(
                name: "CupomId",
                table: "TBCliente");
        }
    }
}
