using webapi.inlock.codeFirst.Contexts;
using webapi.inlock.codeFirst.Domains;
using webapi.inlock.codeFirst.Interfaces;
using webapi.inlock.codeFirst.Utils;

namespace webapi.inlock.codeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// variavel privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InLockContext ctx;

        /// <summary>
        /// construtor do repositorio
        /// toda vez que o repositorio for instanciado,
        /// ele tera acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InLockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
