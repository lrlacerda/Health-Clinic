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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var clinicas = _clinicaRepository.Listar();
                return Ok(clinicas);
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
                var clinica = _clinicaRepository.BuscarPorId(id);
                if (clinica == null)
                {
                    return NotFound();
                }

                return Ok(clinica);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);
                return StatusCode(201, clinica);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Clinica clinica)
        {
            try
            {
                clinica.IdClinica = id;
                _clinicaRepository.Atualizar(clinica);
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
                _clinicaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("FiltrarPorCNPJ")]
        public IActionResult FiltrarPorCNPJ(string cnpj)
        {
            try
            {
                var clinicas = _clinicaRepository.FiltrarPorCNPJ(cnpj);
                return Ok(clinicas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
