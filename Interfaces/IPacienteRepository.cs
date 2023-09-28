using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);
        void Deletar(Guid id);
        void Atualizar(Paciente paciente);

        List<Paciente> Listar();
        Paciente BuscarPorId(Guid id);
        List<Paciente> BuscarPorNome(string nome);
        List<Paciente> ListarPorGenero(Guid idGenero);
        int ContarPacientes();
    }
}
