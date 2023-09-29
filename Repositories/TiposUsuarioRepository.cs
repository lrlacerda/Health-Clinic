using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public TiposUsuarioRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Atualizar(TiposUsuario tiposUsuario)
        {
            _clinicContext.TiposUsuarios.Update(tiposUsuario);
            _clinicContext.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            return _clinicContext.TiposUsuarios.Find(id)!;
        }

        public void Cadastrar(TiposUsuario tiposUsuario)
        {
            _clinicContext.TiposUsuarios.Add(tiposUsuario);
            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var tiposUsuario = _clinicContext.TiposUsuarios.Find(id);
            if (tiposUsuario != null)
            {
                _clinicContext.TiposUsuarios.Remove(tiposUsuario);
                _clinicContext.SaveChanges();
            }
        }

        public List<TiposUsuario> Listar()
        {
            return _clinicContext.TiposUsuarios.ToList();
        }
    }
}
