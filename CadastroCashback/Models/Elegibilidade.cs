using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCashback.Models
{
    [Table("elegibilidade")]
    [PrimaryKey(nameof(CampanhaId),nameof(ModeloCartaoId), nameof(EstabelecimentoComercialId), nameof(MccId))]
    public class Elegibilidade 
    {
        [Column("campanha_id")]
        public int CampanhaId { get; set; }
        public Campanha Campanha { get; set; }

        [Column("modelo_cartao_id")]
        public int ModeloCartaoId { get; set; }
        public ModeloCartao ModeloCartao { get; set; }

        [Column("estabelecimento_comercial_id")]
        public int EstabelecimentoComercialId { get; set; }
        public EstabelecimentoComercial EstabelecimentoComercial { get; set; }

        [Column("mcc_id")]
        public int MccId { get; set; }
        public Mcc Mcc { get; set; }
    }
}
