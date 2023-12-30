using ControleDoAcervo.Livros;

namespace UsuariosBiblioteca.Interfaces
{
    public interface IUsuario
    {
        bool Login();
        void Logout();
        void PesquisarLivro(string livroBuscado);
    }
}
