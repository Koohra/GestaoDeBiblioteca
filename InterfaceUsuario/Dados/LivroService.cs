using ControleDoAcervo.Livros;
using Newtonsoft.Json.Linq;

namespace SistemaBiblioteca.Dados
{
    internal class LivroService
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
                Livros.Add(ConverterJsonParaLivro(livroJSON));
        }

        public void CriarLivro(Livro novoLivro)
        {
            try
            {
                var json = File.ReadAllText(Caminho); 
                var livros = JArray.Parse(json); 
                var novoLivroJson = JObject.FromObject(novoLivro); 
                livros.Add(novoLivroJson); 
                Livros.Add(novoLivro);
                File.WriteAllText(Caminho, livros.ToString());

                Console.WriteLine("Livro criado com sucesso.");
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
                var json = File.ReadAllText(Caminho);
                JArray livrosJSON = JArray.Parse(json);

                foreach (var livro in Livros)
                {
                    livro.ExibirInformacoes();
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler todos os livrosJSON: {e}");
            }
        }

        public void LerLivroPorID(int id)
        {
            try
            {
                var json = File.ReadAllText(Caminho);
                var livros = JArray.Parse(json);
                var livro = livros.FirstOrDefault(livro => livro["ID"].Value<int>() == id);

                if (livro != null)
                    ExibirInformacoesDoLivro(livro);
                else
                    Console.WriteLine($"Livro com ID {id} não encontrado.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler o livro com ID {id}: {e}");
            }
        }

        private void ExibirInformacoesDoLivro(JToken livro)
        {
            Console.WriteLine($"Título: {livro["Titulo"]}");
            Console.WriteLine($"Autor: {livro["Autor"]}");
            Console.WriteLine($"Ano de publicação: {livro["AnoPublicacao"]}");
            Console.WriteLine($"Setor / Acervo: {livro["SetorLocal"]}");
        }

        public void AlterarLivroPorID(int id, Livro livroAtualizado)
        {
            try
            {
                var json = File.ReadAllText(Caminho);
                var livros = JArray.Parse(json);

                var livroParaAtualizar = livros.FirstOrDefault(l => l["ID"].Value<int>() == id);
                Livro livro = ConverterJsonParaLivro(livroParaAtualizar);

                if (livroParaAtualizar != null)
                {
                    File.WriteAllText(Caminho, livros.ToString());
                    livro.ExibirInformacoes();
                    Console.WriteLine($"Livro com ID {id} atualizado com sucesso.");
                }
                else
                    Console.WriteLine($"Livro com ID {id} não encontrado.");
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
                var json = File.ReadAllText(Caminho);
                var livros = JArray.Parse(json);

                var livroParaDeletar = livros.FirstOrDefault(l => l["ID"].Value<int>() == id);
                if (livroParaDeletar != null)
                {
                    livros.Remove(livroParaDeletar);
                    File.WriteAllText(Caminho, livros.ToString());
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

        private Livro ConverterJsonParaLivro(JToken livroJson)
        {
            string titulo = livroJson["Titulo"].ToString();
            string autor = livroJson["Autor"].ToString();
            int anoPublicacao = livroJson["AnoPublicacao"].Value<int>();

            Dictionary<EstadoExemplar, int> exemplares = new Dictionary<EstadoExemplar, int>();

            foreach (var estado in Enum.GetValues(typeof(EstadoExemplar)).Cast<EstadoExemplar>())
            {
                string estadoStr = estado.ToString();
                if (livroJson["Exemplares"][estadoStr] != null)
                    exemplares.Add(estado, livroJson["Exemplares"][estadoStr].Value<int>());
                else
                    exemplares.Add(estado, 0);
            }

            Livro livro = new(titulo, autor, anoPublicacao, exemplares);
            return livro;
        }
    }
}
