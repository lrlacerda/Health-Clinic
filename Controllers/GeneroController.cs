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
