using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ControleDoAcervo.Livros
{
    public class LivroService
    {
        public string Caminho { get; private set; }
        public List<Livro> Livros { get; private set; } = new List<Livro>();

        public LivroService(string? arquivo = "LivrosAcervo.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Livros", arquivo);
            Caminho = Caminho.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "AcervoLivro");

            var json = File.ReadAllText(Caminho);
            JArray livrosJSON = JArray.Parse(json);

            foreach (var livroJSON in livrosJSON)
            {
                Livro? livro = JsonConvert.DeserializeObject<Livro?>(livroJSON.ToString());
                if (livro != null)
                    Livros.Add(livro);
            }
        }

        public bool VerificaSeLivroJaExiste(Livro livro)
        {
            Livro? livroIgual = Livros.FirstOrDefault(l => l.Titulo == livro.Titulo && l.Autor == livro.Autor);
            if (livroIgual != null)
                return true;
            return false;
        }

        public void CriarLivro(Livro novoLivro)
        {
            try
            {
                if (VerificaSeLivroJaExiste(novoLivro))
                    Console.WriteLine("Este livro já existe no sistema.");
                else
                {
                    Livros.Add(novoLivro);
                    var json = JsonConvert.SerializeObject(Livros, Formatting.Indented);
                    File.WriteAllText(Caminho, json);
                    Console.WriteLine("Livro criado com sucesso.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível criar um livro: {e}");
            }
        }

        public List<Livro> LerLivros()
        {
            try
            {
                Console.WriteLine("\nTodos os livros do Sistema de Biblioteca:");
                foreach (var livro in Livros)
                {
                    livro.ExibirInformacoes();
                    Console.WriteLine();
                }
                return Livros;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler todos os livros do arquivo JSON: {e}");
                return Livros;
            }
        }

        public Livro LerLivroPorID(int id)
        {
            try
            {
                Livro? livro = Livros.FirstOrDefault(livro => livro.Id == id);

                if (livro != null)
                {
                    Console.WriteLine("Livro encontrado:\n");
                    livro.ExibirInformacoes();
                }
                else
                    Console.WriteLine($"Livro com ID {id} não encontrado.");
                return livro;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler o livro com ID {id}: {e}");
                return null;
            }
        }

        public void AlterarLivroPorID(int id, Livro livroAtualizado)
        {
            try
            {
                if (VerificaSeLivroJaExiste(livroAtualizado))
                {
                    Console.WriteLine("Livro com as mudanças solicitadas já existe no sistema.");
                    return;
                }

                Livro? livroParaAtualizar = Livros.FirstOrDefault(livro => livro.Id == id);

                if (livroParaAtualizar != null)
                {
                    Livros.Remove(livroParaAtualizar);
                    livroParaAtualizar.Titulo = livroAtualizado.Titulo;
                    livroParaAtualizar.Autor = livroAtualizado.Autor;
                    livroParaAtualizar.AnoPublicacao = livroAtualizado.AnoPublicacao;
                    livroParaAtualizar.AtualizarExemplares();
                    livroParaAtualizar.Reservas = livroAtualizado.Reservas;
                    Livros.Add(livroParaAtualizar);

                    var json = JsonConvert.SerializeObject(Livros, Formatting.Indented);
                    File.WriteAllText(Caminho, json);

                    Console.WriteLine($"Livro com ID {id} atualizado com sucesso.");
                    livroParaAtualizar.ExibirInformacoes();
                }
                else
                {
                    Console.WriteLine($"Livro com ID {id} não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível alterar o livro com ID {id}: {e}");
            }
        }

        public void DeletarLivroPorID(int id)
        {
            try
            {
                var livroParaDeletar = Livros.FirstOrDefault(livro => livro.Id == id);
                if (livroParaDeletar != null)
                {
                    Livros.Remove(livroParaDeletar);
                    var json = JsonConvert.SerializeObject(Livros, Formatting.Indented);
                    File.WriteAllText(Caminho, json);
                    Console.WriteLine($"Livro com ID {id} deletado com sucesso.");
                }
                else
                    Console.WriteLine($"Livro com ID {id} não encontrado.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível deletar o livro com ID {id}: {e}");
            }
        }

        public void DeletarLivroTitulo(string titulo, string autor, int anoPublicacao)
        {
            try
            {
                foreach (var livro in Livros)
                {
                    if (livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase) &&
                        livro.Autor.Equals(titulo, StringComparison.OrdinalIgnoreCase) &&
                        livro.AnoPublicacao.Equals(anoPublicacao))
                    {
                        Livros.Remove(livro);
                        var json = JsonConvert.SerializeObject(Livros, Formatting.Indented);
                        File.WriteAllText(Caminho, json);
                        Console.WriteLine($"O livro {titulo} foi deletado com sucesso.");
                    }
                    else
                        Console.WriteLine($"O livro {titulo} não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível deletar o livro {titulo}: {e}");
            }
        }
    }
}

