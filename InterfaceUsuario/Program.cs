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
            Dictionary<EstadoExemplar, int> exemplares2 = new Dictionary<EstadoExemplar, int>
            {
                { EstadoExemplar.Conservado, 3 },
                { EstadoExemplar.Perdido, 1 },
                { EstadoExemplar.TotalmenteDanificado, 3 },
                { EstadoExemplar.MalConservado, 4 },
                { EstadoExemplar.Emprestado, 2 }
            };

            Dictionary<EstadoExemplar, int> exemplares3 = new Dictionary<EstadoExemplar, int>
            {
                { EstadoExemplar.Conservado, 1 },
                { EstadoExemplar.Perdido, 1 },
                { EstadoExemplar.TotalmenteDanificado, 3 },
                { EstadoExemplar.MalConservado, 4 },
                { EstadoExemplar.Emprestado, 2 }
            };

            livroService.CriarLivro(new Livro("O ladrão de raios", "Rick Riordan", 2010, exemplares));
            livroService.CriarLivro(new Livro("O mar de monstros", "Rick Riordan", 2011, exemplares));
            livroService.CriarLivro(new Livro("A maldição do titã", "Rick Riordan", 2012, exemplares));
            livroService.CriarLivro(new Livro("teste", "Rick Riordan", 2015, exemplares));
            livroService.LerLivros();
            livroService.LerLivroPorID(2);

            livroService.AlterarLivroPorID(3, new Livro("outro livro", "Rick Riordan", 2017, exemplares3));
            livroService.DeletarLivroPorID(3);
        }
    }
}
