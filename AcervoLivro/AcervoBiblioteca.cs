using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public class AcervoBiblioteca
    {
        private static List<Livro>? Livros { get; set; } = new List<Livro>();
        protected LivroService livroService { get; private set; } = new LivroService();

        public AcervoBiblioteca() { }

        public static void AdicionarLivro()
        {
            bool esperaAnoValido = true;
            Dictionary<EstadoExemplar, int> estadosLivroNovo = [];

            Console.Write("Digite o título do livro que você deseja adicionar: ");
            string? titulo = Console.ReadLine();

            while (string.IsNullOrEmpty(titulo))
            {
                Console.Write("O título do livro não pode ser vazio. Por favor, digite novamente: ");
                titulo = Console.ReadLine();
            }

            Console.Write("Digite o autor do livro: ");
            string? autor = Console.ReadLine();

            while (string.IsNullOrEmpty(autor))
            {
                Console.Write("O autor do livro não pode ser vazio. Por favor, digite novamente: ");
                autor = Console.ReadLine();
            }

            int anoPublicacao = 0;

            do
            {
                Console.Write("Digite o ano de publicação do livro: ");

                esperaAnoValido = int.TryParse(Console.ReadLine(), out anoPublicacao);
                if (!esperaAnoValido)
                    Console.WriteLine("Este não é um ano de publicação válido.");

            } while (!esperaAnoValido);

            estadosLivroNovo = Livro.ReceberEstadoExemplar();

            Livro novoLivro = new(titulo, autor, anoPublicacao, estadosLivroNovo);

            LivroService livroService = new();
            livroService.CriarLivro(novoLivro);
        }

        public void RemoverLivroPorTitulo()
        {
            try
            {
                Console.Write("Digite o título do livro que você deseja remover: ");
                string? titulo = Console.ReadLine();

                while (string.IsNullOrEmpty(titulo))
                {
                    Console.Write("O título do livro não pode ser vazio. Por favor, digite novamente: ");
                    titulo = Console.ReadLine();
                }

                livroService.DeletarLivroTitulo(titulo);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Erro ao deletar o livro: {e}");
            }
        }

        public void RemoverLivroPorID()
        {
            try
            {
                bool esperaIDValido;
                do
                {
                    Console.WriteLine("Digite o ID do livro que você deseja remover:");

                    esperaIDValido = int.TryParse(Console.ReadLine(), out int id);

                    if (esperaIDValido)
                        livroService.DeletarLivroPorID(id);
                    else
                        Console.WriteLine("Este não é um valor válido para Id.");
                } while (esperaIDValido);    
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao deletar o livro: {e}");
            }
        }

        public virtual List<Livro> BuscarLivroPorNome(string? parteTitulo)
        {   
            List<Livro> livrosEncontrados = [];
            Livros = livroService.LerLivros();

            while (string.IsNullOrEmpty(parteTitulo))
            {
                Console.WriteLine("O título do livro não pode ser vazio. Por favor, digite novamente:");
                parteTitulo = Console.ReadLine();
            }

            try
            {
                foreach (var livro in Livros!)
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

        public static void ExibirInformacoesLivros(List<Livro> listaParaLer)
        {
            try
            {
                foreach (var livro in listaParaLer)
                    livro.ExibirInformacoes();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler todos os livros da lista: {e}");
            }
        }
    }
}
