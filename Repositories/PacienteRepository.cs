using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Health_Clinic_API_Lucas.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext _clinicContext;

        public PacienteRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Atualizar(Paciente paciente)
        {
            _clinicContext.Pacientes.Update(paciente);
            _clinicContext.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
            return _clinicContext.Pacientes.Find(id)!;
        }

        public List<Paciente> BuscarPorNome(string nome)
        {
            return _clinicContext.Pacientes
               .Where(paciente => paciente.Nome!.Contains(nome))
               .ToList();
        }

        public void Cadastrar(Paciente paciente)
        {
            _clinicContext.Pacientes.Add(paciente);
            _clinicContext.SaveChanges();
        }

        public int ContarPacientes()
        {
            return _clinicContext.Pacientes.Count();
        }

        public void Deletar(Guid id)
        {
            var paciente = _clinicContext.Pacientes.Find(id);
            if (paciente != null)
            {
                _clinicContext.Pacientes.Remove(paciente);
                _clinicContext.SaveChanges();
            }
        }

        public List<Paciente> Listar()
        {
            return _clinicContext.Pacientes
           .Include(p => p.Genero)
           .Select(p => new Paciente
           {
               IdPaciente = p.IdPaciente,
               Nome = p.Nome,
               DataNascimento = p.DataNascimento,
               Endereco = p.Endereco,
               IdUsuario = p.IdUsuario,
               Genero = new Genero
               {
                   NomeGenero = p.Genero!.NomeGenero
               },
           })
           .ToList();
        }

        public List<Paciente> ListarPorGenero(Guid idGenero)
        {
            return _clinicContext.Pacientes
                .Where(paciente => paciente.IdGenero == idGenero)
                .ToList();
        }
    }
}
