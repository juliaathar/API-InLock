using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
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

        /// <summary>
        /// endpoint que aciona o método de listar estúdios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona o método de cadastrar estúdios
        /// </summary>
        /// <param name="novoEstudio"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona o método de deletar estúdios
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
