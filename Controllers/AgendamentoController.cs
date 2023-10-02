using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;
using Health_Clinic_API_Lucas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_API_Lucas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AgendamentoController : ControllerBase
    {
        private IAgendamentoRepository _agendamentoRepository;

        public AgendamentoController()
        {
            _agendamentoRepository = new AgendamentoRepository();
        }
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
