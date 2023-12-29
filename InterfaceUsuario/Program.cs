using UsuariosBiblioteca.Professores;
using UsuariosBiblioteca.Funcionarios;
using ControleDoAcervo.Livros;

namespace SistemaBiblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BEM VINDO À BIBLIOTECA");
            FazerLogin.EscolherUsuario();
        }
    }
}
