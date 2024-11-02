using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCashback.Models
{
    [Table("tb_modelo_cartao")]
    public class ModeloCartao
    {

        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set;}

        public ICollection<Elegibilidade> Elegibilidade { get; set; } = [];

    }
}
