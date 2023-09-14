using webapi.inlock.codeFirst.Domains;

namespace webapi.inlock.codeFirst.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();

        Estudio BuscarPorId(Guid id);

        void Cadastrar(Jogo novoJogo);

        void Atualizar(Guid id, Jogo jogo);

        void Deletar(Guid id);

    }
}
