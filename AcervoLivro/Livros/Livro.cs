using System.Text.Json;
namespace ControleDoAcervo.Livros
{
    public class Livro
    {
        private static int contadorId = 0;
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int AnoPublicacao { get; private set; }
        public Dictionary<EstadoExemplar, int> Exemplares { get; private set; }
        public Acervo SetorLocal { get; private set; }
        public List<string> ListaDeReserva { get; private set; }

        public Livro(string titulo, string autor, int anoPublicacao, Dictionary<EstadoExemplar, int> exemplares)
        {
            Id = contadorId++;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Exemplares = exemplares;
            VerificarSetor(exemplares);
            ListaDeReserva = new List<string>();
        }

        private void VerificarSetor(Dictionary<EstadoExemplar, int> exemplares)
        {
            int quantidadeTotalLivros = exemplares.Values.Sum();
            foreach (var (estado, quantidade) in exemplares)
            {
                if (estado == EstadoExemplar.Conservado && quantidade > 2)
                {
                    SetorLocal = Acervo.Publico;
                    break;
                }
                else if (estado == EstadoExemplar.Conservado && quantidade == 1 ||
                         estado == EstadoExemplar.MalConservado && quantidade == quantidadeTotalLivros)
                {
                    SetorLocal = Acervo.Restrito;
                    break;
                }
                else if (estado == EstadoExemplar.Conservado && quantidade == 0)
                {
                    SetorLocal = Acervo.ForaDeEstoque;
                    break;
                }
            }
        }

        public void AtualizarExemplares(Dictionary<EstadoExemplar, int> exemplares) 
        {
            Exemplares = exemplares;
            VerificarSetor(Exemplares);
        }

        public void AdicionarExemplar(EstadoExemplar estado, int quantidade)
        {
            if (Exemplares.ContainsKey(estado))
                Exemplares[estado] += quantidade;
            else
            {
                bool deuCerto = Exemplares.TryAdd(estado, quantidade);
                if (!deuCerto)
                    throw new ArgumentException("Não foi possível adicionar exemplar.");
            }

            VerificarSetor(Exemplares);
        }

        public void RemoverExemplar(EstadoExemplar estado, int quantidade)
        {
            if (Exemplares.ContainsKey(estado) && Exemplares[estado] >= quantidade)
                Exemplares[estado] -= quantidade;
            else
                throw new ArgumentException("Não existe a quantidade de exemplares neste estado deste livro.");

            VerificarSetor(Exemplares);
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Ano de publicação: {AnoPublicacao}");
            Console.WriteLine($"Setor / Acervo: {SetorLocal}");
        }

        public void ConverterObjetoParaJson(Livro livro)
        {
            //string caminhoArquivoJson = * Adicionar o caminho do arquivo json dos livros.
            // Serializa o Objeto para um json
            string jsonString = JsonSerializer.Serialize(livro);
            //try
            //{
            //    if (File.Exists(caminhoArquivoJson))
            //    {
            //        string existeJson = File.ReadAllText(caminhoArquivoJson);
            //        var jsonArray = JsonDocument.Parse(existeJson).RootElement;

            //        var AdicionarObjetoNoArray = JsonDocument.Parse(jsonString).RootElement;
            //        jsonArray.Append(AdicionarObjetoNoArray);

            //        File.WriteAllText(caminhoArquivoJson, jsonArray.ToString());
            //    }
            //    else
            //    {
            //        File.WriteAllText(caminhoArquivoJson, $"[{jsonString}]");
            //    }
            //    Console.WriteLine("Objeto adicionado ao arquivo JSON com sucesso.");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            //}
        }
    }
}
