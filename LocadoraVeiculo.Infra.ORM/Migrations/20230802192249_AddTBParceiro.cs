using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraVeiculo.Infra.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddTBParceiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salario",
                table: "TBFuncionario",
                type: "Decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");

            migrationBuilder.CreateTable(
                name: "TBParceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBParceiro", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBParceiro");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salario",
                table: "TBFuncionario",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(38,17)");
        }
    }
}
