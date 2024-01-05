using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public class ForaDeEstoque: AcervoBiblioteca
    {
        public static List<Livro> LivrosForaDeEstoque { get; private set; } = [];

        public ForaDeEstoque() { }

        public override List<Livro> BuscarLivroPorNome(string? parteTitulo)
        {
            List<Livro> livrosEncontrados = [];
            LivrosForaDeEstoque = livroService.LerLivros().Where(livro => livro.Setor == Acervo.ForaDeEstoque).ToList();

            while (string.IsNullOrEmpty(parteTitulo))
            {
                Console.WriteLine("O título do livro não pode ser vazio. Por favor, digite novamente:");
                parteTitulo = Console.ReadLine();
            }

            try
            {
                foreach (var livro in LivrosForaDeEstoque)
                {
                    if (livro.Titulo.Contains(parteTitulo, StringComparison.OrdinalIgnoreCase))
                        livrosEncontrados.Add(livro);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao buscar livro por parte do nome: {e}");
            }

            return livrosEncontrados;
        }
    }
}
