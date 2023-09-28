using Health_Clinic.Domains;

namespace Health_Clinic_API_Lucas.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);
        void Deletar(Guid id);
        List<Comentario> Listar();
        Comentario BuscarPorId(Guid id);
        List<Comentario> ListarComentariosPorMedico(Guid idMedico);
        List<Comentario> ListarComentariosPorPaciente(Guid idPaciente);
        void ResponderComentario(Guid idComentario, string resposta);
        List<Comentario> ListarComentariosNaoRespondidos();
        List<Comentario> FiltrarPorAvaliacao(int avaliacao);
    }
}
