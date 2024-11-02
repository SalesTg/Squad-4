using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCashback.Models
{
    [Table("tb_modo_entrada")]
    public class ModoEntrada
    {

        [Key]
        public int Id { get; set; }

        [Column("ds_modo_entrada")]
        public string DsModoEntrada { get; set; }

    }
}
