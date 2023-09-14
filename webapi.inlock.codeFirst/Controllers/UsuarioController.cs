using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codeFirst.Domains;
using webapi.inlock.codeFirst.Interfaces;
using webapi.inlock.codeFirst.Repositories;

namespace webapi.inlock.codeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
