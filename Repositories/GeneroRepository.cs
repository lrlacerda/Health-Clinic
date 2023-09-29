using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public GeneroRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Atualizar(Genero genero)
        {
            _clinicContext.Generos.Update(genero);
            _clinicContext.SaveChanges();
        }

        public Genero BuscarPorId(Guid id)
        {
            return _clinicContext.Generos.Find(id)!;
        }

        public void Cadastrar(Genero genero)
        {
            _clinicContext.Generos.Add(genero);
            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var genero = _clinicContext.Generos.Find(id);
            if (genero != null)
            {
                _clinicContext.Generos.Remove(genero);
                _clinicContext.SaveChanges();
            }
        }

        public List<Genero> Listar()
        {
            return _clinicContext.Generos.ToList();
        }

        public List<Genero> ListarGenerosPopulares(int quantidade)
        {
            return _clinicContext.Generos
                .OrderByDescending(genero => genero.NomeGenero)
                .Take(quantidade)
                .ToList();
        }

        public List<Genero> ListarGenerosPorNome(string nome)
        {
            return _clinicContext.Generos
               .Where(genero => genero.NomeGenero.Contains(nome))
               .ToList();
        }
    }
}
