using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;
using Health_Clinic_API_Lucas.Repositories;
using Health_Clinic_API_Lucas.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Health_Clinic_API_Lucas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Realiza a autenticação de um usuário com base em seu email e senha.
        /// </summary>
        /// <param name="usuario">As credenciais de login do usuário.</param>
        /// <returns>Um token de autenticação JWT se o login for bem-sucedido.</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel usuario)
        {
            //LoginViewModel usuarioBuscado = usuario;

            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou Senha Inválidos");
                }

                //Lógica do Token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario!.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TiposUsuario.Nome!),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthclinic-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                        issuer: "Health_Clinic_API_Lucas",

                        audience: "Health_Clinic_API_Lucas",

                        claims: claims,

                        expires: DateTime.Now.AddMinutes(10),

                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {
                return StatusCode(500, new { message = erro.Message });
            }
        }
    }
}
