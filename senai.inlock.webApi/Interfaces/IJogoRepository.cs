using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IJogoRepository 
    {
        void Cadastrar(JogoDomain novoJogo);
        List<JogoDomain> ListarTodos();
        void Atualizar(JogoDomain jogo);
        void Deletar(int id);
        JogoDomain Buscar(int id);
    }
}
