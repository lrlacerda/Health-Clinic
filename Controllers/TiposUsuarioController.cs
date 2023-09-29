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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var tiposUsuarios = _tiposUsuarioRepository.Listar();
                return Ok(tiposUsuarios);
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
                var tiposUsuario = _tiposUsuarioRepository.BuscarPorId(id);
                if (tiposUsuario == null)
                {
                    return NotFound();
                }

                return Ok(tiposUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);
                return StatusCode(201, tiposUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposUsuario tiposUsuario)
        {
            try
            {
                tiposUsuario.IdTiposUsuario = id;
                _tiposUsuarioRepository.Atualizar(tiposUsuario);
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
                _tiposUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

