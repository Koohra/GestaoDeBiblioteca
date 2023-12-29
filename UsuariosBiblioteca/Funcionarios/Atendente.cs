using ControleDoAcervo.Livros;
using UsuariosBiblioteca.Estudantes;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Funcionarios
{
    public class Atendente : Funcionario
    {


        public Atendente(string codigoCadastro, string nome, string email, string senha) : base(codigoCadastro, nome, email, senha)
        {
            Cargo = Cargos.Atendente;
        }

        public void RegistroUsuario() { }// provavelmente tem que receber algo
        public void PermitirEmprestimo(Livro livro, Estudante aluno) { }
        public void AtualizarRegistroUsuario() { } // provavelmente tem que receber algo


    }
}
