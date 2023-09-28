using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);
        void Deletar(Guid id);
        void Atualizar(Clinica clinica);

        List<Clinica> Listar();
        Clinica BuscarPorId(Guid id);
        List<Clinica> FiltrarPorCNPJ(string cnpj);
    }
}
