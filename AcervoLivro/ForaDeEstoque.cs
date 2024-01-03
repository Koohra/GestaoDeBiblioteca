using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    internal class ForaDeEstoque: AcervoBiblioteca
    {
        public static List<Livro> LivrosForaDeEstoque { 
            get
            {
                LivroService livroService = new LivroService();
                LivrosForaDeEstoque = livroService.LerLivros().Where(livro => livro.Setor == Acervo.ForaDeEstoque).ToList();
                return LivrosForaDeEstoque;
            }
            private set 
            { 

            } 
        }

        public ForaDeEstoque() { }

        public override List<Livro> BuscarLivroPorParteDoNome()
        {
            List<Livro> livrosEncontrados = new List<Livro>();

            Console.WriteLine("Digite o título do livro ou parte dele:");
            string? parteTitulo = Console.ReadLine();

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
