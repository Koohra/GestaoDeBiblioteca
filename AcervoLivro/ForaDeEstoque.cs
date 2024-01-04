using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public class ForaDeEstoque: AcervoBiblioteca
    {
        public static List<Livro> LivrosForaDeEstoque { get; private set; } = new List<Livro>();

        public ForaDeEstoque() { }

        public override List<Livro> BuscarLivroPorParteDoNome(string? parteTitulo)
        {
            List<Livro> livrosEncontrados = new List<Livro>();
            LivrosForaDeEstoque = livroService.LerLivros();

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
                    {
                        livrosEncontrados.Add(livro);
                    }

                    ExibirInformacoesLivros(livrosEncontrados);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao buscar livro por parte do nome: {e}");
            }

            return livrosEncontrados;
        }

        public override void VerificarDisponibilidade(Livro livro) { }
    }
}
