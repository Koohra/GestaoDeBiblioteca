using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Estudantes
{
    internal class Estudante : IUsuario
    {
        public int Matricula { get; private set; }
        public string? Curso { get; set; }
        public int AnoDeIngresso { get; set; }
        public bool LivroEmprestado { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void PesquisarLivro(string livroBuscado)
        {
            throw new NotImplementedException();
        }
    }
}