using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuarioDomain novoTipoUsuario);
        List<TiposUsuarioDomain> ListarTodos();
        void Deletar(int id);
    }
}
