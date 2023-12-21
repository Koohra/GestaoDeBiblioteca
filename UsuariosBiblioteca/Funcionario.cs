using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDoAcervo;
using ControleDoAcervo.Livros;

namespace UsuariosBiblioteca
{
    internal class Funcionario : Usuario
    {
        public string Login { get; set; }
        private string Senha {  get; set; }

        public Funcionario(string nome, string login, string senha) : base(nome)
        {
            Login = login;
            Senha = senha;
        }

        public void VerificarStatusLivro(Livro livro)
        {
            AcervoBiblioteca.VerificarDisponibilidade(livro);
        }

        public void CadastrarLivro(string titulo, string autor, int anoPublicacao, Dictionary<ControleDoAcervo.Livros.EstadoExemplar, int> exemplares, ControleDoAcervo.Livros.Acervo setor)
        {
            AcervoBiblioteca.AdicionarLivro(new ControleDoAcervo.Livros.Livro(titulo, autor, anoPublicacao, exemplares, setor));
        }

        public void AtualizarNumeroLivros()
        {

        }

        //public void ValidarSenha()
        //{
        //    isso fica aqui ou em interface?
        //}
    }
}
