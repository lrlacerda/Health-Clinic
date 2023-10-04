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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Obtém a lista de todos os tipos de usuário.
        /// </summary>
        /// <returns>Uma lista de objetos TiposUsuario.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var tiposUsuarios = _tiposUsuarioRepository.Listar();
                return Ok(tiposUsuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém um tipo de usuário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do tipo de usuário.</param>
        /// <returns>O tipo de usuário encontrado ou NotFound se não existir.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var tiposUsuario = _tiposUsuarioRepository.BuscarPorId(id);
                if (tiposUsuario == null)
                {
                    return NotFound();
                }

                return Ok(tiposUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário.
        /// </summary>
        /// <param name="tiposUsuario">Os dados do tipo de usuário a ser cadastrado.</param>
        /// <returns>O tipo de usuário cadastrado com status HTTP 201 (Created).</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);
                return StatusCode(201, tiposUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um tipo de usuário existente.
        /// </summary>
        /// <param name="id">O ID do tipo de usuário a ser atualizado.</param>
        /// <param name="tiposUsuario">Os novos dados do tipo de usuário.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposUsuario tiposUsuario)
        {
            try
            {
                tiposUsuario.IdTiposUsuario = id;
                _tiposUsuarioRepository.Atualizar(tiposUsuario);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Exclui um tipo de usuário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do tipo de usuário a ser excluído.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

