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
            Estudio estudioBuscado = ctx.Estudios.Find(id)!;

            if(estudioBuscado == null)
            {
                estudioBuscado.Nome = estudio.Nome
            }

            ctx.Estudios.Update(estudioBuscado!);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio estudio)
        {
            estudio.IdEstudio = Guid.NewGuid();

            ctx.Estudios.Add(estudio);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            ctx.Estudios.Remove(estudioBuscado);

            ctx.SaveChanges();  //após toda alteracao de dados no banco tem que ser salvo
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
