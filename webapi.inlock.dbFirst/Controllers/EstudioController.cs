using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.dbFirst.Interfaces;
using webapi.inlock.dbFirst.Repositories;

namespace webapi.inlock.dbFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception erro)
            {
               return BadRequest(erro.Message);
            }
        }

        [HttpGet("ListarComJogos")]

        public IActionResult GetWithGames()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(id));
            }
            catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
