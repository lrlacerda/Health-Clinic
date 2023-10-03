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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Obtém a lista de todos os pacientes.
        /// </summary>
        /// <returns>Uma lista de objetos Paciente.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pacientes = _pacienteRepository.Listar();
                return Ok(pacientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém um paciente pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente.</param>
        /// <returns>O paciente encontrado ou NotFound se não existir.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var paciente = _pacienteRepository.BuscarPorId(id);
                if (paciente == null)
                {
                    return NotFound();
                }

                return Ok(paciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém pacientes pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome do paciente.</param>
        /// <returns>Uma lista de pacientes que correspondem ao nome especificado.</returns>
        [HttpGet("PorNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            try
            {
                var pacientes = _pacienteRepository.BuscarPorNome(nome);
                return Ok(pacientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém pacientes por gênero.
        /// </summary>
        /// <param name="idGenero">O ID do gênero.</param>
        /// <returns>Uma lista de pacientes do gênero especificado.</returns>
        [HttpGet("PorGenero/{idGenero}")]
        public IActionResult ListarPorGenero(Guid idGenero)
        {
            try
            {
                var pacientes = _pacienteRepository.ListarPorGenero(idGenero);
                return Ok(pacientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        /// <param name="paciente">Os dados do paciente a ser cadastrado.</param>
        /// <returns>O paciente cadastrado com status HTTP 201 (Created).</returns>
        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);
                return StatusCode(201, paciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um paciente existente.
        /// </summary>
        /// <param name="id">O ID do paciente a ser atualizado.</param>
        /// <param name="paciente">Os novos dados do paciente.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                paciente.IdPaciente = id;
                _pacienteRepository.Atualizar(paciente);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Exclui um paciente pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente a ser excluído.</param>
        /// <returns>Nenhum conteúdo com status HTTP 204 (NoContent) se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
