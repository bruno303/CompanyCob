using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyCob.Repository.Migrations
{
    public partial class telefone_carteira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelefoneContato",
                table: "Carteira",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefoneContato",
                table: "Carteira");
        }
    }
}
