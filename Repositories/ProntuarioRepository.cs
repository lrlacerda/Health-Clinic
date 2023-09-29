using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public ProntuarioRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Atualizar(Prontuario prontuario)
        {
            _clinicContext.Prontuarios.Update(prontuario);
            _clinicContext.SaveChanges();
        }

        public Prontuario BuscarPorId(Guid id)
        {
            return _clinicContext.Prontuarios.Find(id)!;
        }

        public void Cadastrar(Prontuario prontuario)
        {
            _clinicContext.Prontuarios.Add(prontuario);
            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var prontuario = _clinicContext.Prontuarios.Find(id);
            if (prontuario != null)
            {
                _clinicContext.Prontuarios.Remove(prontuario);
                _clinicContext.SaveChanges();
            }
        }

        public List<Prontuario> Listar()
        {
            return _clinicContext.Prontuarios.ToList();
        }

        public List<Prontuario> ListarProntuariosPorMedico(Guid idMedico)
        {
            return _clinicContext.Prontuarios
               .Where(prontuario => prontuario.IdMedico == idMedico)
               .ToList();
        }

        public List<Prontuario> ListarProntuariosPorPaciente(Guid idPaciente)
        {
            return _clinicContext.Prontuarios
                .Where(prontuario => prontuario.IdPaciente == idPaciente)
                .ToList();
        }
    }
}
