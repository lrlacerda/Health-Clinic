using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IAgendamentoRepository
    {
        void Cadastrar(Agendamento agendamento);
        void Deletar(Guid id);
        List<Agendamento> Listar();
        List<Agendamento> ListarAgendamentosPorUsuario(Guid idUsuario);
    }
}
