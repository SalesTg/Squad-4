using CadastroCashback.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace CadastroCashback.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campanha>()
            .Property(x => x.TipoPremiacao)
            .HasConversion(
                v => v.ToString()[0],
                v => (ETipoPremiacao)v
            );

        modelBuilder.Entity<Campanha>()
            .Property(x => x.TipoCredito)
            .HasConversion(
                v => v.ToString()[0],
                v => (ETipoCredito)v
            );

        modelBuilder.Entity<Campanha>()
            .Property(x => x.FatorCategorizacao)
            .HasConversion(
                v => v.ToString()[0],
                v => (EFatorCategorizacao)v
            );

        modelBuilder.Entity<Campanha>()
            .Property(x => x.Mecanica)
            .HasConversion(
                v => v.ToString()[0],
                v => (EMecanica)v
            );
        modelBuilder.Entity<Campanha>()
            .Property(x => x.TipoExecacao)
            .HasConversion(
                v => v.ToString()[0],
                v => (ETipoExecacao)v
            );
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Campanha> Campanhas { get; set; }
    public DbSet<ModoEntrada> ModoEntrada { get; set; }
    public DbSet<ModeloCartao> ModeloCartao { get; set; }
    public DbSet<EstabelecimentoComercial> EstabelecimentoComercial { get; set; }
    public DbSet<Mcc> Mcc { get; set; }
    public DbSet<Elegibilidade> Elegibilidade { get; set; }

}