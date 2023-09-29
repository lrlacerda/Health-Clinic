using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public EspecialidadeRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Atualizar(Especialidade especialidade)
        {
            _clinicContext.Especialidades.Update(especialidade);
            _clinicContext.SaveChanges();
        }

        public Especialidade BuscarPorId(Guid id)
        {
            return _clinicContext.Especialidades.Find(id)!;
        }

        public void Cadastrar(Especialidade especialidade)
        {
            _clinicContext.Especialidades.Add(especialidade);
            _clinicContext.SaveChanges();
        }

        public int ContarEspecialidades()
        {
            return _clinicContext.Especialidades.Count();
        }

        public void Deletar(Guid id)
        {
            var especialidade = _clinicContext.Especialidades.Find(id);
            if (especialidade != null)
            {
                _clinicContext.Especialidades.Remove(especialidade);
                _clinicContext.SaveChanges();
            }
        }

        public List<Especialidade> Listar()
        {
            return _clinicContext.Especialidades.ToList();
        }

        public List<Especialidade> ListarEspecialidadesPorNome(string nome)
        {
            return _clinicContext.Especialidades
                .Where(especialidade => especialidade.NomeEspecialidade!.Contains(nome))
                .ToList();
        }
    }
}
