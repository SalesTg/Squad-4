using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCashback.Models
{
    [Table("campanhas")]
    public class Campanha
    {
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("tipo_premiacao", TypeName ="char(1)")]
        public ETipoPremiacao TipoPremiacao { get; set; }

        [Column("tipo_credito", TypeName = "char(1)")]
        public ETipoCredito TipoCredito { get; set; }

        [Column("valor_cashback")]
        public decimal ValorCashback { get; set; }

        [Column("percentual_cashback")]
        public decimal PercentualCashback { get; set; }

        [Column("pontos_por_real")]
        public decimal PontosPorReal { get; set; }

        [Column("fator_categorizacao", TypeName = "char(1)")]
        public EFatorCategorizacao FatorCategorizacao{ get; set; }

        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime DataFim { get; set; }

        [Column("limite_quantitativo")]
        public int LimiteQuantitativo { get; set; }

        [Column("mecanica", TypeName = "char(1)")]
        public EMecanica Mecanica { get; set; }

        [Column("tipo_excecao", TypeName = "char(1)")]
        public ETipoExecacao? TipoExecacao { get; set; }

        [Column("valor_minimo_transacao")]
        public decimal ValorMinimoTransacao { get; set; }

        public ICollection<Elegibilidade> Elegibilidade { get; set; } = [];

    }
}
