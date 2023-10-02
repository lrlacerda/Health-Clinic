using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public UsuarioRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Atualizar(Usuario usuario)
        {
            _clinicContext.Usuarios.Update(usuario);
            _clinicContext.SaveChanges();
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _clinicContext.Usuarios
           .Include(u => u.TiposUsuario)
           .FirstOrDefault(u => u.IdUsuario == id)!;
        }

        public void Cadastrar(Usuario usuario)
        {
            var tiposUsuario = _clinicContext.TiposUsuarios.Find(usuario.IdTiposUsuario);

            
            if (tiposUsuario != null)
            {
               
                usuario.TiposUsuario = tiposUsuario;
            }

            _clinicContext.Usuarios.Add(usuario);

            _clinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var usuario = _clinicContext.Usuarios.Find(id);
            if (usuario != null)
            {
                _clinicContext.Usuarios.Remove(usuario);
                _clinicContext.SaveChanges();
            }
        }

        public List<Usuario> Listar()
        {
            return _clinicContext.Usuarios
            .Include(u => u.TiposUsuario)
            .ToList();
        }
    }
}
