using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public class AcervoPublico: AcervoBiblioteca
    {
        public List<Livro> LivrosPublicos {
            get
            {
                LivroService livroService = new LivroService();
                LivrosPublicos = livroService.LerLivros().Where(livro => livro.Setor == Acervo.Publico).ToList();
                return LivrosPublicos;
            }
            private set { }
        }

        //public AcervoPublico() 
        //{
        //    LivrosPublicos = new List<Livro>();
        //}

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
                foreach (var livro in LivrosPublicos)
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
        //Acho que não faz sentido, pq quando não está disponível, já está fora de estoque
    }
}
