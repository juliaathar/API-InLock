using webapi.inlock.codeFirst.Domains;

namespace webapi.inlock.codeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}
