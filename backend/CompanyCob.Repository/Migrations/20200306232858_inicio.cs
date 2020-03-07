using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyCob.Repository.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carteira",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    QtdParcelasMaxima = table.Column<int>(nullable: false),
                    TipoJuros = table.Column<int>(nullable: false),
                    PercentualJuros = table.Column<decimal>(type: "money", nullable: false),
                    Comissao = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divida",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DevedorId = table.Column<int>(nullable: false),
                    CarteiraId = table.Column<int>(nullable: false),
                    NumeroDivida = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    ValorOriginal = table.Column<decimal>(type: "money", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divida_Carteira_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Divida_Devedor_DevedorId",
                        column: x => x.DevedorId,
                        principalTable: "Devedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Divida_CarteiraId",
                table: "Divida",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Divida_DevedorId",
                table: "Divida",
                column: "DevedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Divida");

            migrationBuilder.DropTable(
                name: "Carteira");

            migrationBuilder.DropTable(
                name: "Devedor");
        }
    }
}
