using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public class AcervoPublico: AcervoBiblioteca
    {
        public static List<Livro>? LivrosPublicos { get; private set; } = [];

        public AcervoPublico() {  }

        public override List<Livro> BuscarLivroPorNome(string? parteTitulo)
        {
            List<Livro> livrosEncontrados = new();
            LivrosPublicos = livroService.LerLivros().Where(livro => livro.Setor == Acervo.Publico).ToList();

            while (string.IsNullOrEmpty(parteTitulo))
            {
                Console.WriteLine("O título do livro não pode ser vazio. Por favor, digite novamente:");
                parteTitulo = Console.ReadLine();
            }

            try
            {
                foreach (var livro in LivrosPublicos)
                {
                    if (livro.Titulo.Contains(parteTitulo, StringComparison.OrdinalIgnoreCase))
                        livrosEncontrados.Add(livro);
                }
                return livrosEncontrados;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao buscar livro por parte do nome: {e}");
                return livrosEncontrados;
            }
        }
    }
}
