using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void VerificarStatusLivro()
        {
            Console.WriteLine("Digite nome do livro desejado:");
            string busca = Console.ReadLine();
            //essas coisas ainda não existem então editar para nomes certos quando existirem. Isso fica aqui ou em livros e só é puxado?
            //bool encontrado = false;
            //foreach (Livro livro in acervo)
            //{
            //    if (livro.nome.Contains(busca) == true)
            //    {
            //        Console.WriteLine($"{livro.nome} - {livro.status}");
            //        encontrado = true;
            //    }
            //}
            //if (encontrado == false)
            //{
            //    Console.WriteLine("Livro não encontrado.");
            //}
            //tratar para ser aceito tanto letras maiusculas quanto minusculas.

        }

        public void CadastrarLivro()
        {
            //chama função de livro
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
