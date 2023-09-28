using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);
        void Deletar(Guid id);
        void Atualizar(Consulta consulta);

        List<Consulta> Listar();
        Consulta BuscarPorId(Guid id);
        List<Consulta> ListarConsultasPorMedico(Guid idMedico);
        List<Consulta> ListarConsultasPorPaciente(Guid idPaciente);
    }
}
