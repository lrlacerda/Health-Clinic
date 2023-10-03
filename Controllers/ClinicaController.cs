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

        /// <summary>
        /// Obtém a lista de todas as clínicas.
        /// </summary>
        /// <returns>Uma lista de objetos Clinica.</returns>
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

        /// <summary>
        /// Obtém uma clínica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da clínica a ser obtida.</param>
        /// <returns>A clínica encontrada.</returns>
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

        /// <summary>
        /// Cadastra uma nova clínica.
        /// </summary>
        /// <param name="clinica">O objeto Clinica a ser cadastrado.</param>
        /// <returns>A clínica cadastrada.</returns>
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

        /// <summary>
        /// Atualiza uma clínica existente.
        /// </summary>
        /// <param name="id">O ID da clínica a ser atualizada.</param>
        /// <param name="clinica">O objeto Clinica com as informações atualizadas.</param>
        /// <returns>Nenhum conteúdo.</returns>
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

        /// <summary>
        /// Deleta uma clínica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da clínica a ser deletada.</param>
        /// <returns>Nenhum conteúdo.</returns>
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

        /// <summary>
        /// Filtra clínicas pelo CNPJ.
        /// </summary>
        /// <param name="cnpj">O CNPJ a ser usado como critério de filtro.</param>
        /// <returns>Uma lista de clínicas que correspondem ao CNPJ fornecido.</returns>
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
