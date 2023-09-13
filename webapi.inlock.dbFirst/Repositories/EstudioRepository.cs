using Microsoft.EntityFrameworkCore;
using webapi.inlock.dbFirst.Contexts;
using webapi.inlock.dbFirst.Domains;
using webapi.inlock.dbFirst.Interfaces;

namespace webapi.inlock.dbFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext(); //instancia da classe context para ter acesso ao que está no context
        public void Atualizar(Guid id, Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
