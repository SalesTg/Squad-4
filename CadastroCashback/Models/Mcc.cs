using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCashback.Models
{
    [Table("tb_mcc")]
    public class Mcc
    {
        [Key]
        public int Id { get; set; }

        [Column("codigo_mcc")]
        public string CodigoMcc { get; set; }

        [Column("descricao_mcc")]
        public string DescricaoMcc { get;}

        public ICollection<Elegibilidade> Elegibilidade { get; set; } = [];
    }
}
