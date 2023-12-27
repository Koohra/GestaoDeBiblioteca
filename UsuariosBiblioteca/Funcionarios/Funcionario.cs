using ControleDoAcervo.Livros;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Funcionarios
{
    public class Funcionario : IUsuario, ISenha
    {
        public string CodigoCadastro { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Cargos Cargo { get; set; } 
        private string Senha { get; set; }
        

        public Funcionario(string codigoCadastro, string nome, string email, Cargos cargo, string senha)
        {
            CodigoCadastro = codigoCadastro;
            Nome = nome;
            Email = email;
            Cargo = cargo;
            Senha = senha;
            
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
