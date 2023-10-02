using Health_Clinic.Domains;
using Microsoft.EntityFrameworkCore;

namespace Health_Clinic.Contexts
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Prontuario> Prontuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=NOTE06-S15; DataBase=Health_Clinic_API_Lucas; User Id=sa; Password=Senai@134; TrustServerCertificate=True;");
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=LAPTOP-LUCAS\\SQLEXPRESS; DataBase=Health_Clinic_API_Lucas; User Id=sa; Password=Vidanova7836#; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
