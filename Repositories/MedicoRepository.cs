using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic_API_Lucas.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _clinicContext.Medicos.Find(id)!;
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
            //return _clinicContext.Medicos.ToList();
            return _clinicContext.Medicos
            .Include(m => m.Clinica)
            .Include(m => m.Usuario)
            .Include(m => m.Especialidade)
            .Select(m => new Medico
            {
                IdMedico = m.IdMedico,
                Nome = m.Nome,
                CRM = m.CRM,
                Telefone = m.Telefone,

                Clinica = new Clinica
                {
                    TelefoneClinica = m.Clinica!.TelefoneClinica,
                    NomeFantasia = m.Clinica.NomeFantasia,
                    Endereco = m.Clinica.Endereco,
                },
                Usuario = new Usuario
                {
                    Email = m.Usuario!.Email,
                    TiposUsuario = m.Usuario.TiposUsuario,
                    DataRegistro = m.Usuario.DataRegistro,

                },
                Especialidade = new Especialidade
                {
                    NomeEspecialidade = m.Especialidade!.NomeEspecialidade

                }
            })
         .ToList();
        }

        public List<Medico> ListarMedicosPorEspecialidade(Guid idEspecialidade)
        {

            return _clinicContext.Medicos
           .Include(m => m.Clinica)
           .Include(m => m.Usuario)
           .Include(m => m.Especialidade)
           .Select(m => new Medico
           {
               IdMedico = m.IdMedico,
               Nome = m.Nome,
               CRM = m.CRM,
               Telefone = m.Telefone,

               Clinica = new Clinica
               {
                   TelefoneClinica = m.Clinica!.TelefoneClinica,
                   NomeFantasia = m.Clinica.NomeFantasia,
                   Endereco = m.Clinica.Endereco,
               },
               Especialidade = new Especialidade
               {
                   NomeEspecialidade = m.Especialidade!.NomeEspecialidade

               }
           })
                .ToList();
        }
    }
}
