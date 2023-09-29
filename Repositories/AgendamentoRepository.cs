using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public AgendamentoRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Cadastrar(Agendamento agendamento)
        {
            _clinicContext.Agendamentos.Add(agendamento);
            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var agendamento = _clinicContext.Agendamentos.Find(id);
            if (agendamento != null)
            {
                _clinicContext.Agendamentos.Remove(agendamento);
                _clinicContext.SaveChanges();
            }
        }

        public List<Agendamento> Listar()
        {
            return _clinicContext.Agendamentos.ToList();
        }

        public List<Agendamento> ListarAgendamentosPorPaciente(Guid idPaciente)
        {
            return _clinicContext.Agendamentos
               .Where(agendamento => agendamento.IdPaciente == idPaciente)
               .ToList();
        }
    }
}
