using System;
using System.Text.Json;
namespace ControleDoAcervo
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public int QuantitadeExemplares { get; set; }
        public string SetorLocal { get; set; }
        public List<string> ListaDeReserva { get; set; }

        public Livro(string titulo, string autor, int anoPublicacao, int quantidadeExemplares, string setor)
        {
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            QuantitadeExemplares = quantidadeExemplares;
            SetorLocal = setor;

        }

        public void ConverteObjetoParaJson(Livro livro)
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
