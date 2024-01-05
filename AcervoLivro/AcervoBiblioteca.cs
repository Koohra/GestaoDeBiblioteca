using ControleDoAcervo.Livros;
using System.Collections.Generic;
using System.Text;

namespace ControleDoAcervo
{
    public class AcervoBiblioteca
    {
        public static List<Livro> Livros { get; private set; } = new List<Livro>();
        protected LivroService livroService { get; set; } = new LivroService();

        public AcervoBiblioteca() { }

        public static void AdicionarLivro()
        {
            bool esperaAno = true;
            Dictionary<EstadoExemplar, int> estadosLivroNovo = new Dictionary<EstadoExemplar, int>();

            Console.WriteLine("Digite o título do livro que você deseja adicionar:");
            string? titulo = Console.ReadLine();

            while (string.IsNullOrEmpty(titulo))
            {
                Console.WriteLine("O título do livro não pode ser vazio. Por favor, digite novamente:");
                titulo = Console.ReadLine();
            }

            Console.WriteLine("Digite o autor do livro:");
            string? autor = Console.ReadLine();

            while (string.IsNullOrEmpty(autor))
            {
                Console.WriteLine("O autor do livro não pode ser vazio. Por favor, digite novamente:");
                autor = Console.ReadLine();
            }
            int anoPublicacao = 0;
            do
            {
                Console.WriteLine("Digite o ano de publicação do livro");
                if (int.TryParse(Console.ReadLine(), out int ano))
                {
                    anoPublicacao = ano;
                    esperaAno = false;
                }
                else
                {
                    Console.WriteLine("Este não é um ano de publicação válido.");
                }
            } while (esperaAno);
            estadosLivroNovo = Livro.ReceberEstadoExemplar();

            Livro novoLivro = new Livro(titulo, autor, anoPublicacao, estadosLivroNovo);

            LivroService livroService = new LivroService();
            livroService.CriarLivro(novoLivro);
        }

        public void RemoverLivroTitulo()
        {
            try
            {
                bool esperaAno = true;

                Console.WriteLine("Digite o título do livro que você deseja remover:");
                string? titulo = Console.ReadLine();

                while (string.IsNullOrEmpty(titulo))
                {
                    Console.WriteLine("O título do livro não pode ser vazio. Por favor, digite novamente:");
                    titulo = Console.ReadLine();
                }

                Console.WriteLine("Digite o autor do livro:");
                string? autor = Console.ReadLine();

                while (string.IsNullOrEmpty(autor))
                {
                    Console.WriteLine("O autor do livro não pode ser vazio. Por favor, digite novamente:");
                    autor = Console.ReadLine();
                }
                int anoPublicacao = 0;
                do
                {
                    Console.WriteLine("Digite o ano de publicação do livro");
                    if (int.TryParse(Console.ReadLine(), out int ano))
                    {
                        anoPublicacao = ano;
                        esperaAno = false;
                    }
                    else
                    {
                        Console.WriteLine("Este não é um ano de publicação válido.");
                    }
                } while (esperaAno);

                livroService.DeletarLivroTitulo(titulo, autor, anoPublicacao);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Erro ao deletar o livro: {e}");
            }
        }

        public void RemoverLivroId()
        {
            try
            {
                bool esperaId = true;
                do
                {
                    Console.WriteLine("Digite o ID do livro que você deseja remover:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        int idLivro = id;
                        livroService.DeletarLivroPorID(idLivro);
                        esperaId = false;
                    }
                    else
                    {
                        Console.WriteLine("Este não é um valor válido para Id.");
                    }
                } while (esperaId);    
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao deletar o livro: {e}");
            }
        }



        public virtual List<Livro> BuscarLivroPorParteDoNome(string? parteTitulo)
        {   
            List<Livro> livrosEncontrados = new List<Livro>();
            Livros = livroService.LerLivros();

            while (string.IsNullOrEmpty(parteTitulo))
            {
                Console.WriteLine("O título do livro não pode ser vazio. Por favor, digite novamente:");
                parteTitulo = Console.ReadLine();
            }

            try
            {
                foreach (var livro in Livros)
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

        public void ExibirInformacoesLivros(List<Livro> listaParaLer)
        {
            try
            {
                foreach (var livro in listaParaLer)
                {
                    livro.ExibirInformacoes();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler todos os livros da lista: {e}");
               
            }
        }

        public virtual void VerificarDisponibilidade(Livro livro) { }
        //Acho que não faz sentido, pq quando não está disponível, já está fora de estoque

    }
}
