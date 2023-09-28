using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);
        void Deletar(Guid id);
        void Atualizar(Especialidade especialidade);

        List<Especialidade> Listar();
        Especialidade BuscarPorId(Guid id);
        List<Especialidade> ListarEspecialidadesPorNome(string nome);
        int ContarEspecialidades();

    }
}
