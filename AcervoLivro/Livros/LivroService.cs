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
            Livro? livroIgual = Livros.FirstOrDefault(l => l.Titulo == livro.Titulo && l.Autor == livro.Autor && l.Reservas == livro.Reservas);
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

        public void SalvarJsonLivro(List<Livro> livros, string? arquivoJson = "LivrosAcervo.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Livros", arquivoJson);
            Caminho = Caminho.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "AcervoLivro");
            
            try
            {
                if (File.Exists(Caminho)) // conferir se vai dar erro
                {
                    // Serializa a lista de livros de volta para o formato JSON
                    string json = JsonConvert.SerializeObject(livros, Formatting.Indented);

                    // Escreve o JSON de volta no arquivo
                    File.WriteAllText(Caminho, json);

                    Console.WriteLine("Alterações salvas com sucesso no arquivo JSON.");
                }
                else
                {
                    Console.WriteLine("Não foi encontrado nenhum arquivo JSON para ser atualizado.");
                }
            }
            catch (Exception ex3)
            {
                Console.WriteLine("Ocorreu um erro ao tentar salvar as alterações no arquivo JSON: " + ex3.Message);
            }
        }

        public void EmprestarLivro(int id, Dictionary<EstadoExemplar, int> exemplarAtualizado)
        {
            List<Livro>? livros = LerLivros();
            Livro? livroParaAtualizar = Livros.FirstOrDefault(livro => livro.Id == id);

            if (livroParaAtualizar != null)
            {
                livroParaAtualizar.Exemplares = exemplarAtualizado;

                SalvarJsonLivro(livros);

                Console.WriteLine($"Livro com ID {id} atualizado com sucesso.");
                livroParaAtualizar.ExibirInformacoes();
            }
        }

        public void ReceberLivro()
        {

        }
    }
}

