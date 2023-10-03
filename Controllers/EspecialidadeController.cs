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

        /// <summary>
        /// Obtém a lista de todas as especialidades médicas.
        /// </summary>
        /// <returns>Uma lista de objetos Especialidade.</returns>
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

        /// <summary>
        /// Obtém uma especialidade médica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da especialidade médica a ser obtida.</param>
        /// <returns>A especialidade médica encontrada.</returns>
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

        /// <summary>
        /// Cadastra uma nova especialidade médica.
        /// </summary>
        /// <param name="especialidade">O objeto Especialidade a ser cadastrado.</param>
        /// <returns>A especialidade médica cadastrada.</returns>
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

        /// <summary>
        /// Atualiza uma especialidade médica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da especialidade médica a ser atualizada.</param>
        /// <param name="especialidade">O objeto Especialidade atualizado.</param>
        /// <returns>Nenhum conteúdo.</returns>
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

        /// <summary>
        /// Deleta uma especialidade médica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da especialidade médica a ser deletada.</param>
        /// <returns>Nenhum conteúdo.</returns>
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
