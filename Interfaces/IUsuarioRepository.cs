using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Deletar(Guid id);
        void Atualizar(Usuario usuario);
        Usuario BuscarPorEmailESenha(string email, string senha);
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
    }
}
