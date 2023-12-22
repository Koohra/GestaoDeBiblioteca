using ControleDoAcervo.Livros;

namespace UsuariosBiblioteca.Interfaces
{
    internal interface IUsuario
    {
        void Login();
        void Logout();
        void PesquisarLivro(string livroBuscado);
    }
}
