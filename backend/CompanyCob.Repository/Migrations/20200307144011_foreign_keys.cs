using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyCob.Repository.Migrations
{
    public partial class foreign_keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divida_Carteira_CarteiraId",
                table: "Divida");

            migrationBuilder.DropForeignKey(
                name: "FK_Divida_Devedor_DevedorId",
                table: "Divida");

            migrationBuilder.DropIndex(
                name: "IX_Divida_CarteiraId",
                table: "Divida");

            migrationBuilder.DropIndex(
                name: "IX_Divida_DevedorId",
                table: "Divida");

            migrationBuilder.DropColumn(
                name: "CarteiraId",
                table: "Divida");

            migrationBuilder.DropColumn(
                name: "DevedorId",
                table: "Divida");

            migrationBuilder.AddColumn<int>(
                name: "IdCarteira",
                table: "Divida",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDevedor",
                table: "Divida",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Divida_IdCarteira",
                table: "Divida",
                column: "IdCarteira");

            migrationBuilder.CreateIndex(
                name: "IX_Divida_IdDevedor",
                table: "Divida",
                column: "IdDevedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Divida_Carteira_IdCarteira",
                table: "Divida",
                column: "IdCarteira",
                principalTable: "Carteira",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Divida_Devedor_IdDevedor",
                table: "Divida",
                column: "IdDevedor",
                principalTable: "Devedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divida_Carteira_IdCarteira",
                table: "Divida");

            migrationBuilder.DropForeignKey(
                name: "FK_Divida_Devedor_IdDevedor",
                table: "Divida");

            migrationBuilder.DropIndex(
                name: "IX_Divida_IdCarteira",
                table: "Divida");

            migrationBuilder.DropIndex(
                name: "IX_Divida_IdDevedor",
                table: "Divida");

            migrationBuilder.DropColumn(
                name: "IdCarteira",
                table: "Divida");

            migrationBuilder.DropColumn(
                name: "IdDevedor",
                table: "Divida");

            migrationBuilder.AddColumn<int>(
                name: "CarteiraId",
                table: "Divida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DevedorId",
                table: "Divida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Divida_CarteiraId",
                table: "Divida",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Divida_DevedorId",
                table: "Divida",
                column: "DevedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divida_Carteira_CarteiraId",
                table: "Divida",
                column: "CarteiraId",
                principalTable: "Carteira",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Divida_Devedor_DevedorId",
                table: "Divida",
                column: "DevedorId",
                principalTable: "Devedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
