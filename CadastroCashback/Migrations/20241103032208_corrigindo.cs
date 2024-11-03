using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroCashback.Migrations
{
    /// <inheritdoc />
    public partial class corrigindo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_campanhas_tb_modo_entrada_modo_entrada_id",
                table: "campanhas");

            migrationBuilder.DropIndex(
                name: "IX_campanhas_modo_entrada_id",
                table: "campanhas");

            migrationBuilder.DropColumn(
                name: "modo_entrada_id",
                table: "campanhas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "modo_entrada_id",
                table: "campanhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_campanhas_modo_entrada_id",
                table: "campanhas",
                column: "modo_entrada_id");

            migrationBuilder.AddForeignKey(
                name: "FK_campanhas_tb_modo_entrada_modo_entrada_id",
                table: "campanhas",
                column: "modo_entrada_id",
                principalTable: "tb_modo_entrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
