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
    public class GeneroController : ControllerBase
    {
        private IGeneroRepository _generoRepository;

        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Obtém a lista de todos os gêneros.
        /// </summary>
        /// <returns>Uma lista de objetos Genero.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var generos = _generoRepository.Listar();
                return Ok(generos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém um gênero pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do gênero a ser obtido.</param>
        /// <returns>O gênero encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var genero = _generoRepository.BuscarPorId(id);
                if (genero == null)
                {
                    return NotFound();
                }

                return Ok(genero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo gênero.
        /// </summary>
        /// <param name="genero">O objeto Genero a ser cadastrado.</param>
        /// <returns>O gênero cadastrado.</returns>
        [HttpPost]
        public IActionResult Post(Genero genero)
        {
            try
            {
                _generoRepository.Cadastrar(genero);
                return StatusCode(201, genero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um gênero pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do gênero a ser atualizado.</param>
        /// <param name="genero">O objeto Genero atualizado.</param>
        /// <returns>Nenhum conteúdo.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                genero.IDGenero = id;
                _generoRepository.Atualizar(genero);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta um gênero pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do gênero a ser deletado.</param>
        /// <returns>Nenhum conteúdo.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _generoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma lista de gêneros por nome.
        /// </summary>
        /// <param name="nome">O nome do gênero a ser buscado.</param>
        /// <returns>Uma lista de gêneros encontrados.</returns>
        [HttpGet("PorNome/{nome}")]
        public IActionResult ListarGenerosPorNome(string nome)
        {
            try
            {
                var generos = _generoRepository.ListarGenerosPorNome(nome);
                return Ok(generos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém uma lista de gêneros populares.
        /// </summary>
        /// <param name="quantidade">A quantidade de gêneros populares a serem obtidos.</param>
        /// <returns>Uma lista de gêneros populares.</returns>
        [HttpGet("Populares/{quantidade}")]
        public IActionResult ListarGenerosPopulares(int quantidade)
        {
            try
            {
                var generos = _generoRepository.ListarGenerosPopulares(quantidade);
                return Ok(generos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
