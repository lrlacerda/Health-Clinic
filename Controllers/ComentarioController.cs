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
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository;

        public ComentarioController()
        {
            _comentarioRepository = new ComentarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var comentarios = _comentarioRepository.Listar();
                return Ok(comentarios);
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
                var comentario = _comentarioRepository.BuscarPorId(id);
                if (comentario == null)
                {
                    return NotFound();
                }

                return Ok(comentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(comentario);
                return StatusCode(201, comentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(Guid id, Comentario comentario)
        //{
        //    try
        //    {
        //        comentario.IdComentario = id;
        //        _comentarioRepository.ResponderComentario(id, comentario.Resposta);
        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("PorMedico/{idMedico}")]
        public IActionResult ListarComentariosPorMedico(Guid idMedico)
        {
            try
            {
                var comentarios = _comentarioRepository.ListarComentariosPorMedico(idMedico);
                return Ok(comentarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("PorPaciente/{idPaciente}")]
        public IActionResult ListarComentariosPorPaciente(Guid idPaciente)
        {
            try
            {
                var comentarios = _comentarioRepository.ListarComentariosPorPaciente(idPaciente);
                return Ok(comentarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("FiltrarPorAvaliacao/{avaliacao}")]
        public IActionResult FiltrarPorAvaliacao(int avaliacao)
        {
            try
            {
                var comentarios = _comentarioRepository.FiltrarPorAvaliacao(avaliacao);
                return Ok(comentarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
