using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyCob.Repository.Migrations
{
    public partial class aumentar_tamanho_cpf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Cpf",
                table: "Devedor",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cpf",
                table: "Devedor",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
