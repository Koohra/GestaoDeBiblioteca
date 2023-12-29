namespace ControleDoAcervo.Livros
{
    public class LivroService
    {
        public string Caminho { get; private set; }
        public List<Livro> Livros { get; private set; } = new List<Livro>();

        public LivroService(string? arquivo = "LivrosAcervo.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dados", arquivo);
            Caminho = Caminho.Replace("bin\\Debug\\net8.0\\", "");

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

        public void LerLivros()
        {
            try
            {
                Console.WriteLine("\nTodos os livros do Sistema de Biblioteca:");
                foreach (var livro in Livros)
                {
                    livro.ExibirInformacoes();
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler todos os livros do arquivo JSON: {e}");
            }
        }

        public void LerLivroPorID(int id)
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
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler o livro com ID {id}: {e}");
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
                    livroParaAtualizar.AtualizarExemplares(livroAtualizado.Exemplares);
                    livroParaAtualizar.ListaDeReserva = livroAtualizado.ListaDeReserva;
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
    }
}
