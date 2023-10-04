using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;
using Health_Clinic_API_Lucas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_API_Lucas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(Roles = "Administrador")]
    public class AgendamentoController : ControllerBase
    {
        private IAgendamentoRepository _agendamentoRepository;

        public AgendamentoController()
        {
            _agendamentoRepository = new AgendamentoRepository();
        }

        /// <summary>
        /// Obtém a lista de todos os agendamentos.
        /// </summary>
        /// <returns>Uma lista de objetos Agendamento.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var agendamentos = _agendamentoRepository.Listar();
                return Ok(agendamentos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém a lista de agendamentos de um paciente específico.
        /// </summary>
        /// <param name="idPaciente">O ID do paciente.</param>
        /// <returns>Uma lista de objetos Agendamento do paciente.</returns>
        [HttpGet("PorPaciente/{idPaciente}")]
        public IActionResult ListarAgendamentosPorPaciente(Guid idPaciente)
        {
            try
            {
                var agendamentos = _agendamentoRepository.ListarAgendamentosPorPaciente(idPaciente);
                return Ok(agendamentos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo agendamento.
        /// </summary>
        /// <param name="agendamento">O objeto Agendamento a ser cadastrado.</param>
        /// <returns>O agendamento cadastrado.</returns>
        [HttpPost]
        public IActionResult Post(Agendamento agendamento)
        {
            try
            {
                _agendamentoRepository.Cadastrar(agendamento);
                return StatusCode(201, agendamento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta um agendamento pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do agendamento a ser deletado.</param>
        /// <returns>Nenhum conteúdo.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _agendamentoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
