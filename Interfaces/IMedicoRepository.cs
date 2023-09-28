using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);
        void Deletar(Guid id);
        void Atualizar(Medico medico);

        List<Medico> Listar();
        Medico BuscarPorId(Guid id);
        Medico BuscarPorCRM(int crm);
        List<Medico> ListarMedicosPorEspecialidade(Guid idEspecialidade);
    }
}
