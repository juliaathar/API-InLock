using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]

    public class JogoController : ControllerBase
    {
        IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// endpoint que aciona o método de listar jogos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

                return Ok(listaJogos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona o método de cadastrar jogos
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona o método de deletar jogos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona o método de pesquisar um jogo pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                JogoDomain jogo = _jogoRepository.Buscar(id);

                return Ok(jogo);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona o método de atualizar os dados de um jogo
        /// </summary>
        /// <param name="jogo"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "1")]
        public IActionResult Put(JogoDomain jogo)
        {
            try
            {
                _jogoRepository.Atualizar(jogo);

                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
