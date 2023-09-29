using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public MedicoRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Atualizar(Medico medico)
        {
            _clinicContext.Medicos.Update(medico);
            _clinicContext.SaveChanges();
        }

        public Medico BuscarPorCRM(int crm)
        {
            return _clinicContext.Medicos
                .FirstOrDefault(medico => medico.CRM == crm)!;
        }

        public Medico BuscarPorId(Guid id)
        {
            return _clinicContext.Medicos.Find(id);
        }

        public void Cadastrar(Medico medico)
        {
            _clinicContext.Medicos.Add(medico);
            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var medico = _clinicContext.Medicos.Find(id);
            if (medico != null)
            {
                _clinicContext.Medicos.Remove(medico);
                _clinicContext.SaveChanges();
            };
        }

        public List<Medico> Listar()
        {
            return _clinicContext.Medicos.ToList();
        }

        public List<Medico> ListarMedicosPorEspecialidade(Guid idEspecialidade)
        {
            return _clinicContext.Medicos
                .Where(medico => medico.IdEspecialidade == idEspecialidade)
                .ToList();
        }
    }
}
