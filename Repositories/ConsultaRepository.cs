using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public ConsultaRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Atualizar(Consulta consulta)
        {
            _clinicContext.Consultas.Update(consulta);
            _clinicContext.SaveChanges();
        }

        public Consulta BuscarPorId(Guid id)
        {
            return _clinicContext.Consultas.Find(id)!;
        }

        public void Cadastrar(Consulta consulta)
        {
            _clinicContext.Consultas.Add(consulta);
            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var consulta = _clinicContext.Consultas.Find(id);
            if (consulta != null)
            {
                _clinicContext.Consultas.Remove(consulta);
                _clinicContext.SaveChanges();
            }
        }

        public List<Consulta> Listar()
        {
            return _clinicContext.Consultas.ToList();
        }

        public List<Consulta> ListarConsultasPorMedico(Guid idMedico)
        {
            return _clinicContext.Consultas
                .Where(consulta => consulta.IdMedico == idMedico)
                .ToList();
        }

        public List<Consulta> ListarConsultasPorPaciente(Guid idPaciente)
        {
            return _clinicContext.Consultas
               .Where(consulta => consulta.IdPaciente == idPaciente)
               .ToList();
        }
    }
}
