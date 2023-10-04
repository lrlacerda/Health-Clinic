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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Obtém a lista de todos os médicos.
        /// </summary>
        /// <returns>Uma lista de objetos Médico.</returns>
        [HttpGet]
        [Authorize(Roles = "Administrador, Medico, Paciente")]
        public IActionResult Get()
        {
            try
            {
                var medicos = _medicoRepository.Listar();
                return Ok(medicos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico.</param>
        /// <returns>O médico encontrado ou NotFound se não existir.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var medico = _medicoRepository.BuscarPorId(id);
                if (medico == null)
                {
                    return NotFound();
                }

                return Ok(medico);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém um médico pelo seu CRM.
        /// </summary>
        /// <param name="crm">O número do CRM do médico.</param>
        /// <returns>O médico encontrado ou NotFound se não existir.</returns>
        [HttpGet("PorCRM/{crm}")]
        [Authorize(Roles = "Administrador, Medico, Paciente")]
        public IActionResult GetByCRM(int crm)
        {
            try
            {
                var medico = _medicoRepository.BuscarPorCRM(crm);
                if (medico == null)
                {
                    return NotFound();
                }

                return Ok(medico);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo médico.
        /// </summary>
        /// <param name="medico">Os dados do médico a ser cadastrado.</param>
        /// <returns>O médico cadastrado com status HTTP 201 (Created).</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);
                return StatusCode(201, medico);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um médico existente.
        /// </summary>
        /// <param name="id">O ID do médico a ser atualizado.</param>
        /// <param name="medico">Os novos dados do médico.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult Put(Guid id, Medico medico)
        {
            try
            {
                medico.IdMedico = id;
                _medicoRepository.Atualizar(medico);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Exclui um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser excluído.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém a lista de médicos por especialidade.
        /// </summary>
        /// <param name="idEspecialidade">O ID da especialidade.</param>
        /// <returns>Uma lista de médicos que possuem a especialidade especificada.</returns>
        [HttpGet("PorEspecialidade/{idEspecialidade}")]
        [Authorize(Roles = "Administrador, Medico, Paciente")]
        public IActionResult ListarMedicosPorEspecialidade(Guid idEspecialidade)
        {
            try
            {
                var medicos = _medicoRepository.ListarMedicosPorEspecialidade(idEspecialidade);
                return Ok(medicos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
