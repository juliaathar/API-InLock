using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.Domains
{
    [Table("Estudio")] //data annotation que define que esta classe será uma tabela no banco de dados
    public class Estudio
    {
        [Key] //data annotation que define que será uma chave primária no banco de dados 
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")] //data annotation que define que será uma coluna e qual será seu tipo de dados no banco de dados 
        [Required(ErrorMessage = "Nome do estúdio obrigatório")]
        public string? Nome { get; set; }

        public List<Jogo> Jogo { get; set; }
    }
}
