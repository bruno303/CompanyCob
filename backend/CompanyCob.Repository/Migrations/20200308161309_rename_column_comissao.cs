using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyCob.Repository.Migrations
{
    public partial class rename_column_comissao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comissao",
                table: "Carteira",
                newName: "PercentualComissao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PercentualComissao",
                table: "Carteira",
                newName: "Comissao");
        }
    }
}
