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

        /// <summary>
        /// Obtém a lista de todos os comentários.
        /// </summary>
        /// <returns>Uma lista de objetos Comentario.</returns>
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

        /// <summary>
        /// Obtém um comentário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do comentário a ser obtido.</param>
        /// <returns>O comentário encontrado.</returns>
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

        /// <summary>
        /// Cadastra um novo comentário.
        /// </summary>
        /// <param name="comentario">O objeto Comentario a ser cadastrado.</param>
        /// <returns>O comentário cadastrado.</returns>
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

        /// <summary>
        /// Deleta um comentário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do comentário a ser deletado.</param>
        /// <returns>Nenhum conteúdo.</returns>
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

        /// <summary>
        /// Obtém a lista de comentários associados a um médico.
        /// </summary>
        /// <param name="idMedico">O ID do médico.</param>
        /// <returns>Uma lista de comentários relacionados ao médico.</returns>
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

        /// <summary>
        /// Obtém a lista de comentários associados a um paciente.
        /// </summary>
        /// <param name="idPaciente">O ID do paciente.</param>
        /// <returns>Uma lista de comentários relacionados ao paciente.</returns>
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

        /// <summary>
        /// Filtra comentários por avaliação.
        /// </summary>
        /// <param name="avaliacao">A avaliação a ser usada como critério de filtro.</param>
        /// <returns>Uma lista de comentários que correspondem à avaliação fornecida.</returns>
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
