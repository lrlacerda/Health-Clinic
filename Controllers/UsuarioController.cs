using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;
using Health_Clinic_API_Lucas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Health_Clinic_API_Lucas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Obtém a lista de todos os usuários.
        /// </summary>
        /// <returns>Uma lista de objetos Usuario.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _usuarioRepository.Listar();
                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do usuário.</param>
        /// <returns>O usuário encontrado ou NotFound se não existir.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var usuario = _usuarioRepository.BuscarPorId(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuario">Os dados do usuário a ser cadastrado.</param>
        /// <returns>O usuário cadastrado com status HTTP 201 (Created).</returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201, usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um usuário existente pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser atualizado.</param>
        /// <param name="usuarioAtualizado">Os novos dados do usuário.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Usuario usuarioAtualizado)
        {
            try
            {
                var usuarioExistente = _usuarioRepository.BuscarPorId(id);

                if (usuarioExistente == null)
                {
                    return NotFound();
                }

                usuarioExistente.Nome = usuarioAtualizado.Nome;
                usuarioExistente.Email = usuarioAtualizado.Email;

                _usuarioRepository.Atualizar(usuarioExistente);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Exclui um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser excluído.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
