using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCashback.Models
{
    [Table("tb_estabelecimento_comercial")]
    public class EstabelecimentoComercial 
    {
        [Key]
        public int Id { get; set; }

        [Column("codigo_lojista")]
        public string CodigoLojista { get; set; }

        [Column("nome_lojista")]
        public string NomeLojista { get; set; }

        public ICollection<Elegibilidade> Elegibilidade { get; set; } = [];

    }
}
