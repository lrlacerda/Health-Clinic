using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public ComentarioRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public Comentario BuscarPorId(Guid id)
        {
            return _clinicContext.Comentarios.Find(id);
        }

        public void Cadastrar(Comentario comentario)
        {
            _clinicContext.Comentarios.Add(comentario);
            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var comentario = _clinicContext.Comentarios.Find(id);
            if (comentario != null)
            {
                _clinicContext.Comentarios.Remove(comentario);
                _clinicContext.SaveChanges();
            }
        }

        public List<Comentario> FiltrarPorAvaliacao(int avaliacao)
        {
            return _clinicContext.Comentarios
                .Where(comentario => comentario.Avaliacao == avaliacao)
                .ToList();
        }

        public List<Comentario> Listar()
        {
            return _clinicContext.Comentarios.ToList();
        }

        public List<Comentario> ListarComentariosPorMedico(Guid idMedico)
        {
            return _clinicContext.Comentarios
                .Where(comentario => comentario.IdMedico == idMedico)
                .ToList();
        }

        public List<Comentario> ListarComentariosPorPaciente(Guid idPaciente)
        {
            return _clinicContext.Comentarios
                .Where(comentario => comentario.IdPaciente == idPaciente)
                .ToList();
        }

        public void ResponderComentario(Guid idComentario, string resposta)
        {
            throw new NotImplementedException();
            //var comentario = _clinicContext.Comentarios.Find(idComentario);
            //if (comentario != null)
            //{
            //    comentario.Respondido = resposta;
            //    _clinicContext.SaveChanges();
            //}
        }
    }
}


