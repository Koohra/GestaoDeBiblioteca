using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public  class AcervoRestrito: AcervoBiblioteca
    {
        public static List<Livro> LivrosRestritos { get; private set; } = new List<Livro>();

        public AcervoRestrito() { }

        public override List<Livro> BuscarLivroPorParteDoNome(string? parteTitulo)
        {
            List<Livro> livrosEncontrados = new List<Livro>();
            LivrosRestritos = livroService.LerLivros().Where(livro => livro.Setor == Acervo.Restrito).ToList();

            while (string.IsNullOrEmpty(parteTitulo))
            {
                Console.WriteLine("O título do livro não pode ser vazio. Por favor, digite novamente:");
                parteTitulo = Console.ReadLine();
            }

            try
            {
                foreach (var livro in LivrosRestritos)
                {
                    if (livro.Titulo.Contains(parteTitulo, StringComparison.OrdinalIgnoreCase))
                    {
                        livrosEncontrados.Add(livro);
                    }

                    //ExibirInformacoesLivros(livrosEncontrados);
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
