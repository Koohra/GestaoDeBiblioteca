using ControleDoAcervo.Livros;

namespace UsuariosBiblioteca.Interfaces
{
    public interface IUsuario
    {
        IUsuario Login();
        void Logout();
        void PesquisarLivro();
    }
}
