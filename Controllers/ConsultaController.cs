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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Obtém a lista de todas as consultas médicas.
        /// </summary>
        /// <returns>Uma lista de objetos Consulta.</returns>
        [HttpGet]
        [Authorize(Roles = "Administrador, Medico, Paciente")]
        public IActionResult Get()
        {
            try
            {
                var consultas = _consultaRepository.Listar();
                return Ok(consultas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma consulta médica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta médica a ser obtida.</param>
        /// <returns>A consulta médica encontrada.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador, Medico, Paciente")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var consulta = _consultaRepository.BuscarPorId(id);
                if (consulta == null)
                {
                    return NotFound();
                }

                return Ok(consulta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastra uma nova consulta médica.
        /// </summary>
        /// <param name="consulta">O objeto Consulta a ser cadastrado.</param>
        /// <returns>A consulta médica cadastrada.</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);
                return StatusCode(201, consulta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                
            }
        }

        /// <summary>
        /// Atualiza uma consulta médica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta médica a ser atualizada.</param>
        /// <param name="consulta">O objeto Consulta atualizado.</param>
        /// <returns>Nenhum conteúdo.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult Put(Guid id, Consulta consulta)
        {
            try
            {
                consulta.IdConsulta = id;
                _consultaRepository.Atualizar(consulta);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta uma consulta médica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta médica a ser deletada.</param>
        /// <returns>Nenhum conteúdo.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém a lista de consultas médicas associadas a um médico.
        /// </summary>
        /// <param name="idMedico">O ID do médico.</param>
        /// <returns>Uma lista de consultas médicas relacionadas ao médico.</returns>
        [HttpGet("PorMedico/{idMedico}")]
        [Authorize(Roles = "Administrador, Medico, Paciente")]
        public IActionResult ListarConsultasPorMedico(Guid idMedico)
        {
            try
            {
                var consultas = _consultaRepository.ListarConsultasPorMedico(idMedico);
                return Ok(consultas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém a lista de consultas médicas associadas a um paciente.
        /// </summary>
        /// <param name="idPaciente">O ID do paciente.</param>
        /// <returns>Uma lista de consultas médicas relacionadas ao paciente.</returns>
        [HttpGet("PorPaciente/{idPaciente}")]
        [Authorize(Roles = "Administrador, Medico, Paciente")]
        public IActionResult ListarConsultasPorPaciente(Guid idPaciente)
        {
            try
            {
                var consultas = _consultaRepository.ListarConsultasPorPaciente(idPaciente);
                return Ok(consultas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
