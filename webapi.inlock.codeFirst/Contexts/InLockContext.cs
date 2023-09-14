using Microsoft.EntityFrameworkCore;
using webapi.inlock.codeFirst.Domains;

namespace webapi.inlock.codeFirst.Contexts
{
    public class InLockContext : DbContext
    {
        //define as entidades do banco de dados
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// define as opcoes de construcao do banco(String Conexao)
        /// </summary>
        /// <param name="optionsBuilder">objeto com as configuracoes definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE15-S14; Database= inlock_games_codeFirst_manha; User Id= sa; Pwd= Senai@134; TrustServerCertificate= True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
