using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)] //cria um índice único para
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Senha obrigatória")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Senha deve ter de 6 a 20 caracteres")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Tipo do usuario obrigatorio")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
