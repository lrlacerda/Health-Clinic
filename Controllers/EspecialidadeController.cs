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
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var especialidades = _especialidadeRepository.Listar();
                return Ok(especialidades);
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
                var especialidade = _especialidadeRepository.BuscarPorId(id);
                if (especialidade == null)
                {
                    return NotFound();
                }

                return Ok(especialidade);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);
                return StatusCode(201, especialidade);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Especialidade especialidade)
        {
            try
            {
                especialidade.IdEspecialidade = id;
                _especialidadeRepository.Atualizar(especialidade);
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
                _especialidadeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
