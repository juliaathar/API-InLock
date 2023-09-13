using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatório")]
        public string? Nome  { get; set; }


        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao obrigatória")]
        public string Descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lancamento obrigatória")]
        public DateTime DataLancamento { get; set; }


        [Column(TypeName = "Decimal(4,2)")]
        [Required(ErrorMessage = "Preco do jogo obrigatório")]
        public decimal Preco { get; set; }


        [Required(ErrorMessage = "Informe o estúdio que produziu o jogo")]
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudio Estudio { get; set; }
    }
}
