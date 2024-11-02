using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroCashback.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeNomeColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_campanhas_tb_modo_entrada_ModoEntradaId",
                table: "campanhas");

            migrationBuilder.RenameColumn(
                name: "ModoEntradaId",
                table: "campanhas",
                newName: "modo_entrada_id");

            migrationBuilder.RenameIndex(
                name: "IX_campanhas_ModoEntradaId",
                table: "campanhas",
                newName: "IX_campanhas_modo_entrada_id");

            migrationBuilder.AddForeignKey(
                name: "FK_campanhas_tb_modo_entrada_modo_entrada_id",
                table: "campanhas",
                column: "modo_entrada_id",
                principalTable: "tb_modo_entrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_campanhas_tb_modo_entrada_modo_entrada_id",
                table: "campanhas");

            migrationBuilder.RenameColumn(
                name: "modo_entrada_id",
                table: "campanhas",
                newName: "ModoEntradaId");

            migrationBuilder.RenameIndex(
                name: "IX_campanhas_modo_entrada_id",
                table: "campanhas",
                newName: "IX_campanhas_ModoEntradaId");

            migrationBuilder.AddForeignKey(
                name: "FK_campanhas_tb_modo_entrada_ModoEntradaId",
                table: "campanhas",
                column: "ModoEntradaId",
                principalTable: "tb_modo_entrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
