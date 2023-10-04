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

    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository;

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        /// <summary>
        /// Obtém a lista de todos os prontuários.
        /// </summary>
        /// <returns>Uma lista de objetos Prontuario.</returns>
        [HttpGet]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult Get()
        {
            try
            {
                var prontuarios = _prontuarioRepository.Listar();
                return Ok(prontuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém um prontuário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do prontuário.</param>
        /// <returns>O prontuário encontrado ou NotFound se não existir.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador, Medico, Paciente")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var prontuario = _prontuarioRepository.BuscarPorId(id);
                if (prontuario == null)
                {
                    return NotFound();
                }

                return Ok(prontuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém prontuários de um paciente pelo ID do paciente.
        /// </summary>
        /// <param name="idPaciente">O ID do paciente.</param>
        /// <returns>Uma lista de prontuários do paciente especificado.</returns>
        [HttpGet("PorPaciente/{idPaciente}")]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult ListarPorPaciente(Guid idPaciente)
        {
            try
            {
                var prontuarios = _prontuarioRepository.ListarProntuariosPorPaciente(idPaciente);
                return Ok(prontuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém prontuários de um médico pelo ID do médico.
        /// </summary>
        /// <param name="idMedico">O ID do médico.</param>
        /// <returns>Uma lista de prontuários do médico especificado.</returns>
        [HttpGet("PorMedico/{idMedico}")]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult ListarPorMedico(Guid idMedico)
        {
            try
            {
                var prontuarios = _prontuarioRepository.ListarProntuariosPorMedico(idMedico);
                return Ok(prontuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo prontuário.
        /// </summary>
        /// <param name="prontuario">Os dados do prontuário a ser cadastrado.</param>
        /// <returns>O prontuário cadastrado com status HTTP 201 (Created).</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult Post(Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Cadastrar(prontuario);
                return StatusCode(201, prontuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um prontuário existente.
        /// </summary>
        /// <param name="id">O ID do prontuário a ser atualizado.</param>
        /// <param name="prontuario">Os novos dados do prontuário.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult Put(Guid id, Prontuario prontuario)
        {
            try
            {
                prontuario.IdProntuario = id;
                _prontuarioRepository.Atualizar(prontuario);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Exclui um prontuário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do prontuário a ser excluído.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _prontuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
