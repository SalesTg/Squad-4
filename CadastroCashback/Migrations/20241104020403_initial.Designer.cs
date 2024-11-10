﻿// <auto-generated />
using System;
using CadastroCashback.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroCashback.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20241104020403_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CadastroCashback.Models.Campanha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_fim");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_inicio");

                    b.Property<char>("FatorCategorizacao")
                        .HasColumnType("char(1)")
                        .HasColumnName("fator_categorizacao");

                    b.Property<int>("LimiteQuantitativo")
                        .HasColumnType("int")
                        .HasColumnName("limite_quantitativo");

                    b.Property<char>("Mecanica")
                        .HasColumnType("char(1)")
                        .HasColumnName("mecanica");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.Property<decimal>("PercentualCashback")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("percentual_cashback");

                    b.Property<decimal>("PontosPorReal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("pontos_por_real");

                    b.Property<char>("TipoCredito")
                        .HasColumnType("char(1)")
                        .HasColumnName("tipo_credito");

                    b.Property<char?>("TipoExcecao")
                        .HasColumnType("char(1)")
                        .HasColumnName("tipo_excecao");

                    b.Property<char>("TipoPremiacao")
                        .HasColumnType("char(1)")
                        .HasColumnName("tipo_premiacao");

                    b.Property<decimal>("ValorCashback")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valor_cashback");

                    b.Property<decimal>("ValorMinimoTransacao")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valor_minimo_transacao");

                    b.HasKey("Id");

                    b.ToTable("campanhas");
                });

            modelBuilder.Entity("CadastroCashback.Models.Elegibilidade", b =>
                {
                    b.Property<int>("CampanhaId")
                        .HasColumnType("int")
                        .HasColumnName("campanha_id");

                    b.Property<int>("ModeloCartaoId")
                        .HasColumnType("int")
                        .HasColumnName("modelo_cartao_id");

                    b.Property<int>("EstabelecimentoComercialId")
                        .HasColumnType("int")
                        .HasColumnName("estabelecimento_comercial_id");

                    b.Property<int>("MccId")
                        .HasColumnType("int")
                        .HasColumnName("mcc_id");

                    b.HasKey("CampanhaId", "ModeloCartaoId", "EstabelecimentoComercialId", "MccId");

                    b.HasIndex("EstabelecimentoComercialId");

                    b.HasIndex("MccId");

                    b.HasIndex("ModeloCartaoId");

                    b.ToTable("elegibilidade");
                });

            modelBuilder.Entity("CadastroCashback.Models.EstabelecimentoComercial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoLojista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("codigo_lojista");

                    b.Property<string>("NomeLojista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome_lojista");

                    b.HasKey("Id");

                    b.ToTable("tb_estabelecimento_comercial");
                });

            modelBuilder.Entity("CadastroCashback.Models.Mcc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoMcc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("codigo_mcc");

                    b.HasKey("Id");

                    b.ToTable("tb_mcc");
                });

            modelBuilder.Entity("CadastroCashback.Models.ModeloCartao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_modelo_cartao");
                });

            modelBuilder.Entity("CadastroCashback.Models.ModoEntrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DsModoEntrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ds_modo_entrada");

                    b.HasKey("Id");

                    b.ToTable("tb_modo_entrada");
                });

            modelBuilder.Entity("CadastroCashback.Models.Elegibilidade", b =>
                {
                    b.HasOne("CadastroCashback.Models.Campanha", "Campanha")
                        .WithMany("Elegibilidade")
                        .HasForeignKey("CampanhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroCashback.Models.EstabelecimentoComercial", "EstabelecimentoComercial")
                        .WithMany("Elegibilidade")
                        .HasForeignKey("EstabelecimentoComercialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroCashback.Models.Mcc", "Mcc")
                        .WithMany("Elegibilidade")
                        .HasForeignKey("MccId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroCashback.Models.ModeloCartao", "ModeloCartao")
                        .WithMany("Elegibilidade")
                        .HasForeignKey("ModeloCartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campanha");

                    b.Navigation("EstabelecimentoComercial");

                    b.Navigation("Mcc");

                    b.Navigation("ModeloCartao");
                });

            modelBuilder.Entity("CadastroCashback.Models.Campanha", b =>
                {
                    b.Navigation("Elegibilidade");
                });

            modelBuilder.Entity("CadastroCashback.Models.EstabelecimentoComercial", b =>
                {
                    b.Navigation("Elegibilidade");
                });

            modelBuilder.Entity("CadastroCashback.Models.Mcc", b =>
                {
                    b.Navigation("Elegibilidade");
                });

            modelBuilder.Entity("CadastroCashback.Models.ModeloCartao", b =>
                {
                    b.Navigation("Elegibilidade");
                });
#pragma warning restore 612, 618
        }
    }
}
