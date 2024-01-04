using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public class AcervoPublico: AcervoBiblioteca
    {
        public static List<Livro> LivrosPublicos { get; private set; } = new List<Livro>();

        public AcervoPublico() {  }

        public override List<Livro> BuscarLivroPorParteDoNome()
        {
            List<Livro> livrosEncontrados = new List<Livro>();
            LivrosPublicos = livroService.LerLivros();

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
                    //ExibirInformacoesLivros(livrosEncontrados);
                }
                return livrosEncontrados;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao buscar livro por parte do nome: {e}");
                return livrosEncontrados;
            }
        }

        public override void VerificarDisponibilidade(Livro livro) { }
        //Acho que não faz sentido, pq quando não está disponível, já está fora de estoque
    }
}
