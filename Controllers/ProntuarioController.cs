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
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository;

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpGet("PorPaciente/{idPaciente}")]
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

        [HttpGet("PorMedico/{idMedico}")]
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

        [HttpPost]
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

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
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
