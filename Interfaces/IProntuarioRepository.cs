using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IProntuarioRepository
    {
        void Cadastrar(Prontuario prontuario);
        void Deletar(Guid id);
        void Atualizar(Prontuario prontuario);

        List<Prontuario> Listar();
        Prontuario BuscarPorId(Guid id);
        List<Prontuario> ListarProntuariosPorPaciente(Guid idPaciente);
        List<Prontuario> ListarProntuariosPorMedico(Guid idMedico);
    }
}
