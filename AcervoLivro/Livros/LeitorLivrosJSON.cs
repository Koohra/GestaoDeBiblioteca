using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControleDoAcervo.Livros
{
    public class LeitorLivrosJSON(string caminhoArquivo)
    {
        private string caminhoArquivo = caminhoArquivo;

        public List<Livro> LerLivros()
        {
            List<Livro> livros = new List<Livro>();

            if (File.Exists(caminhoArquivo))
            {
                string conteudoJson = File.ReadAllText(caminhoArquivo);
                livros = JsonSerializer.Deserialize<List<Livro>>(conteudoJson);
            }

            return livros;
        }

        //public void EscreverLivros(List<Livro> livros)
        //{
        //    string conteudoJson = JsonSerializer.Serialize(livros, new JsonSerializerOptions { WriteIndented = true });
        //    File.WriteAllText(caminhoArquivo, conteudoJson);
        //}

        //public void ExcluirArquivo()
        //{
        //    if (File.Exists(caminhoArquivo))
        //    {
        //        File.Delete(caminhoArquivo);
        //    }
        //}
    }

}
