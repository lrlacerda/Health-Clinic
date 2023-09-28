using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IGeneroRepository
    {
        void Cadastrar(Genero genero);
        void Deletar(Guid id);
        void Atualizar(Genero genero);
        List<Genero> Listar();
        Genero BuscarPorId(Guid id);
        List<Genero> ListarGenerosPorNome(string nome);
        List<Genero> ListarGenerosPopulares(int quantidade);
    }
}
