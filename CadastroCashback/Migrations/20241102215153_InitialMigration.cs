using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroCashback.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_estabelecimento_comercial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo_lojista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_lojista = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_estabelecimento_comercial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_mcc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo_mcc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_mcc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_modelo_cartao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_modelo_cartao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_modo_entrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_modo_entrada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_modo_entrada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "campanhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_premiacao = table.Column<string>(type: "char(1)", nullable: false),
                    tipo_credito = table.Column<string>(type: "char(1)", nullable: false),
                    valor_cashback = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    percentual_cashback = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pontos_por_real = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fator_categorizacao = table.Column<string>(type: "char(1)", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    limite_quantitativo = table.Column<int>(type: "int", nullable: false),
                    mecanica = table.Column<string>(type: "char(1)", nullable: false),
                    tipo_excecao = table.Column<string>(type: "char(1)", nullable: true),
                    valor_minimo_transacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModoEntradaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campanhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_campanhas_tb_modo_entrada_ModoEntradaId",
                        column: x => x.ModoEntradaId,
                        principalTable: "tb_modo_entrada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elegibilidade",
                columns: table => new
                {
                    campanha_id = table.Column<int>(type: "int", nullable: false),
                    modelo_cartao_id = table.Column<int>(type: "int", nullable: false),
                    estabelecimento_comercial_id = table.Column<int>(type: "int", nullable: false),
                    mcc_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elegibilidade", x => new { x.campanha_id, x.modelo_cartao_id, x.estabelecimento_comercial_id, x.mcc_id });
                    table.ForeignKey(
                        name: "FK_elegibilidade_campanhas_campanha_id",
                        column: x => x.campanha_id,
                        principalTable: "campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_elegibilidade_tb_estabelecimento_comercial_estabelecimento_comercial_id",
                        column: x => x.estabelecimento_comercial_id,
                        principalTable: "tb_estabelecimento_comercial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_elegibilidade_tb_mcc_mcc_id",
                        column: x => x.mcc_id,
                        principalTable: "tb_mcc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_elegibilidade_tb_modelo_cartao_modelo_cartao_id",
                        column: x => x.modelo_cartao_id,
                        principalTable: "tb_modelo_cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_campanhas_ModoEntradaId",
                table: "campanhas",
                column: "ModoEntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_elegibilidade_estabelecimento_comercial_id",
                table: "elegibilidade",
                column: "estabelecimento_comercial_id");

            migrationBuilder.CreateIndex(
                name: "IX_elegibilidade_mcc_id",
                table: "elegibilidade",
                column: "mcc_id");

            migrationBuilder.CreateIndex(
                name: "IX_elegibilidade_modelo_cartao_id",
                table: "elegibilidade",
                column: "modelo_cartao_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "elegibilidade");

            migrationBuilder.DropTable(
                name: "campanhas");

            migrationBuilder.DropTable(
                name: "tb_estabelecimento_comercial");

            migrationBuilder.DropTable(
                name: "tb_mcc");

            migrationBuilder.DropTable(
                name: "tb_modelo_cartao");

            migrationBuilder.DropTable(
                name: "tb_modo_entrada");
        }
    }
}
