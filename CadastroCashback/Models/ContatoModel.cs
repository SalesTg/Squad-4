using System.ComponentModel.DataAnnotations;

namespace CadastroCashback.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Digite o nome da Campanha")]
        public string Name { get; set; }
        [Required]
        public Boolean IsActive { get; set; }
        [Required]
        public string Limite { get; set; }
        [Required]
        public string Quant { get; set; }
        [Required]
        public int Data {  get; set; }
       

    }
}
