using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public ClinicaRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Atualizar(Clinica clinica)
        {
            _clinicContext.Clinicas.Update(clinica);
            _clinicContext.SaveChanges();
        }

        public Clinica BuscarPorId(Guid id)
        {
            return _clinicContext.Clinicas.Find(id)!;
        }

        public void Cadastrar(Clinica clinica)
        {
            _clinicContext.Clinicas.Add(clinica);
            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var clinica = _clinicContext.Clinicas.Find(id);
            if (clinica != null)
            {
                _clinicContext.Clinicas.Remove(clinica);
                _clinicContext.SaveChanges();
            }
        }

        public List<Clinica> FiltrarPorCNPJ(string cnpj)
        {
            return _clinicContext.Clinicas
                .Where(clinica => clinica.CNPJ!.Contains(cnpj))
                .ToList();
        }

        public List<Clinica> Listar()
        {
            return _clinicContext.Clinicas.ToList();
        }
    }
}
