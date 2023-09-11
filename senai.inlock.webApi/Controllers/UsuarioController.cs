
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        IUsuarioRepository _usuarioRepository {  get; set; }
        public UsuarioController ()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// endpoint que aciona o método de login do usuario
        /// </summary>
        /// <param name="usuarioLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuarioLogin)
        {
            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(usuarioLogin.Email, usuarioLogin.Senha);

                if(usuario == null)
                {
                    return NotFound("Usuário inválido");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-senai-api"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                       issuer: "senai.inlock.webApi.",

                       audience: "wsenai.inlock.webApi.",

                       claims: claims,

                       expires: DateTime.Now.AddMinutes(5),

                       signingCredentials: creds

                    );

                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
