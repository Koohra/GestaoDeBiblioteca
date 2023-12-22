using ControleDoAcervo.Livros;
using UsuariosBiblioteca.Estudantes;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Funcionarios
{
    internal class Atendente : IUsuario
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public void RegistroUsuario() { }// provavelmente tem que receber algo
        public void PermitirEmprestimo(Livro livro, Estudante aluno) { }
        public void AtualizarRegistroUsuario() { } // provavelmente tem que receber algo
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
