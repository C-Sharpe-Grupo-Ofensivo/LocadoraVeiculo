using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraVeiculo.Infra.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddTBAluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_TBAutomovel_AutomovelId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_TBCliente_ClienteId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_TBCondutor_CondutorId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_TBCupom_CupomId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_TBFuncionario_FuncionarioId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_TBGrupoAutomovel_GrupoAutomovelId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_TBPlanoCobranca_PlanoCobrancaId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxaServico_Aluguel_AluguelId",
                table: "TBTaxaServico");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxaServico_AluguelId",
                table: "TBTaxaServico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluguel",
                table: "Aluguel");

            migrationBuilder.DropColumn(
                name: "AluguelId",
                table: "TBTaxaServico");

            migrationBuilder.RenameTable(
                name: "Aluguel",
                newName: "TBAluguel");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_PlanoCobrancaId",
                table: "TBAluguel",
                newName: "IX_TBAluguel_PlanoCobrancaId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_GrupoAutomovelId",
                table: "TBAluguel",
                newName: "IX_TBAluguel_GrupoAutomovelId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_FuncionarioId",
                table: "TBAluguel",
                newName: "IX_TBAluguel_FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_CupomId",
                table: "TBAluguel",
                newName: "IX_TBAluguel_CupomId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_CondutorId",
                table: "TBAluguel",
                newName: "IX_TBAluguel_CondutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_ClienteId",
                table: "TBAluguel",
                newName: "IX_TBAluguel_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_AutomovelId",
                table: "TBAluguel",
                newName: "IX_TBAluguel_AutomovelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBAluguel",
                table: "TBAluguel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TBAluguel_TBTaxaEServico",
                columns: table => new
                {
                    AluguelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxaServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel_TBTaxaEServico", x => new { x.AluguelId, x.TaxaServicoId });
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBTaxaEServico_TBAluguel_AluguelId",
                        column: x => x.AluguelId,
                        principalTable: "TBAluguel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBTaxaEServico_TBTaxaServico_TaxaServicoId",
                        column: x => x.TaxaServicoId,
                        principalTable: "TBTaxaServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_TBTaxaEServico_TaxaServicoId",
                table: "TBAluguel_TBTaxaEServico",
                column: "TaxaServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBAutomovel",
                table: "TBAluguel",
                column: "AutomovelId",
                principalTable: "TBAutomovel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBCliente",
                table: "TBAluguel",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBCondutor",
                table: "TBAluguel",
                column: "CondutorId",
                principalTable: "TBCondutor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBCupom",
                table: "TBAluguel",
                column: "CupomId",
                principalTable: "TBCupom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBFuncionario",
                table: "TBAluguel",
                column: "FuncionarioId",
                principalTable: "TBFuncionario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBGrupoAutomovel",
                table: "TBAluguel",
                column: "GrupoAutomovelId",
                principalTable: "TBGrupoAutomovel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBPlanoCobranca_PlanoCobrancaId",
                table: "TBAluguel",
                column: "PlanoCobrancaId",
                principalTable: "TBPlanoCobranca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBAutomovel",
                table: "TBAluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBCliente",
                table: "TBAluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBCondutor",
                table: "TBAluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBCupom",
                table: "TBAluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBFuncionario",
                table: "TBAluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBGrupoAutomovel",
                table: "TBAluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBPlanoCobranca_PlanoCobrancaId",
                table: "TBAluguel");

            migrationBuilder.DropTable(
                name: "TBAluguel_TBTaxaEServico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBAluguel",
                table: "TBAluguel");

            migrationBuilder.RenameTable(
                name: "TBAluguel",
                newName: "Aluguel");

            migrationBuilder.RenameIndex(
                name: "IX_TBAluguel_PlanoCobrancaId",
                table: "Aluguel",
                newName: "IX_Aluguel_PlanoCobrancaId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAluguel_GrupoAutomovelId",
                table: "Aluguel",
                newName: "IX_Aluguel_GrupoAutomovelId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAluguel_FuncionarioId",
                table: "Aluguel",
                newName: "IX_Aluguel_FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAluguel_CupomId",
                table: "Aluguel",
                newName: "IX_Aluguel_CupomId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAluguel_CondutorId",
                table: "Aluguel",
                newName: "IX_Aluguel_CondutorId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAluguel_ClienteId",
                table: "Aluguel",
                newName: "IX_Aluguel_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAluguel_AutomovelId",
                table: "Aluguel",
                newName: "IX_Aluguel_AutomovelId");

            migrationBuilder.AddColumn<Guid>(
                name: "AluguelId",
                table: "TBTaxaServico",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluguel",
                table: "Aluguel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxaServico_AluguelId",
                table: "TBTaxaServico",
                column: "AluguelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_TBAutomovel_AutomovelId",
                table: "Aluguel",
                column: "AutomovelId",
                principalTable: "TBAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_TBCliente_ClienteId",
                table: "Aluguel",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_TBCondutor_CondutorId",
                table: "Aluguel",
                column: "CondutorId",
                principalTable: "TBCondutor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_TBCupom_CupomId",
                table: "Aluguel",
                column: "CupomId",
                principalTable: "TBCupom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_TBFuncionario_FuncionarioId",
                table: "Aluguel",
                column: "FuncionarioId",
                principalTable: "TBFuncionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_TBGrupoAutomovel_GrupoAutomovelId",
                table: "Aluguel",
                column: "GrupoAutomovelId",
                principalTable: "TBGrupoAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_TBPlanoCobranca_PlanoCobrancaId",
                table: "Aluguel",
                column: "PlanoCobrancaId",
                principalTable: "TBPlanoCobranca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxaServico_Aluguel_AluguelId",
                table: "TBTaxaServico",
                column: "AluguelId",
                principalTable: "Aluguel",
                principalColumn: "Id");
        }
    }
}
