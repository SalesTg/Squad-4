using CadastroCashback.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCashback.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }
    

    public DbSet<Campanha> Campanhas { get; set; }
    public DbSet<ModoEntrada> ModoEntrada { get; set; }
    public DbSet<ModeloCartao> ModeloCartao { get; set; }
    public DbSet<EstabelecimentoComercial> EstabelecimentoComercial { get; set; }
    public DbSet<Mcc> Mcc { get; set; }
    public DbSet<Elegibilidade> Elegibilidade { get; set; }

}