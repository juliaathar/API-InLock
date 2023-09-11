using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// endpoint que aciona o método de listar os tipos de usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TiposUsuarioDomain> listaTiposUsuario = _tiposUsuarioRepository.ListarTodos();

                return Ok(listaTiposUsuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
