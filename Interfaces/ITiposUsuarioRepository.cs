using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario tiposUsuario);
        void Deletar(Guid id);
        void Atualizar(TiposUsuario tiposUsuario);

        List<TiposUsuario> Listar();
        TiposUsuario BuscarPorId(Guid id);
    }
}
