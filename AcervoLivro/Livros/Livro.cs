using System;
using System.Text.Json;
namespace ControleDoAcervo.Livros
{
    public class Livro
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int AnoPublicacao { get; private set; }
        public Dictionary<EstadoExemplar, int> Exemplares { get; private set; }
        public Acervo SetorLocal { get; private set; }
        public List<string> ListaDeReserva { get; private set; }
        // provavelmente em vez de list de string vai ser list de usuario

        public Livro(string titulo, string autor, int anoPublicacao, Dictionary<EstadoExemplar, int> exemplares, Acervo setor)
        {
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Exemplares = exemplares;
            VerificarSetor(exemplares);
            // não sei se precisa setar no construtor porque isso pode ser feito automatico a depender de exemplares
            ListaDeReserva = new List<string>();
        }

        public void Disponivel()
        {
            // não sei se precisa ter esse método
        }

        public void VerificarSetor(Dictionary<EstadoExemplar, int> exemplares)
        {
            int quantidadeTotalLivros = exemplares.Values.Count;
            foreach (var (estado, quantidade) in exemplares)
            {
                if (estado == EstadoExemplar.Conservado && quantidade > 2)
                    SetorLocal = Acervo.Publico;
                else if (estado == EstadoExemplar.Conservado && quantidade == 0)
                    SetorLocal = Acervo.ForaDeEstoque;
                else if (estado == EstadoExemplar.Conservado && quantidade == 1 ||
                         estado == EstadoExemplar.MalConservado && quantidade == quantidadeTotalLivros)
                    SetorLocal = Acervo.Restrito;
                else
                    throw new ArgumentException("Não foi possível definir um acervo para o livro.");
            }
        }

        public void AtualizarExemplares(Dictionary<EstadoExemplar, int> exemplares) 
        {
            Exemplares = exemplares;
            VerificarSetor(exemplares);
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
