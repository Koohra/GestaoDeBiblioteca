using ControleDoAcervo.Livros;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Funcionarios
{
    internal abstract class Funcionario : IUsuario, ISenha
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        private string Senha { get; set; }
        public Cargos Cargo { get; set; } 

        public Funcionario(string nome, string email, string senha, Cargos cargo)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Cargo = cargo;
        }

        public void VerificarStatusLivro(Livro livro)
        {
            // AcervoBiblioteca.VerificarDisponibilidade(livro);
        }

        public void CadastrarLivro(string titulo, string autor, int anoPublicacao, Dictionary<EstadoExemplar, int> exemplares)
        {
            // AcervoBiblioteca.AdicionarLivro(new Livro(titulo, autor, anoPublicacao, exemplares));
        }

        public void AtualizarNumeroLivros()
        {

        }


        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void PesquisarLivro(string livroBuscado)
        {
            
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void ValidarSenha(string senha)
        {
            throw new NotImplementedException();
        }
    }
}
