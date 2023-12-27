using SistemaBiblioteca.Dados;
using ControleDoAcervo.Livros;

namespace InterfaceUsuario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LivroService livroService = new LivroService();
            Dictionary<EstadoExemplar, int> exemplares = new Dictionary<EstadoExemplar, int>
            {
                { EstadoExemplar.Perdido, 1 },
                { EstadoExemplar.TotalmenteDanificado, 3 },
                { EstadoExemplar.MalConservado, 4 },
                { EstadoExemplar.Emprestado, 2 },
                { EstadoExemplar.Conservado, 0 }
            };
            livroService.CriarLivro(new Livro("O mar de monstros", "Rick Riordan", 2010, exemplares));
            livroService.LerLivros();
        }
    }
}
