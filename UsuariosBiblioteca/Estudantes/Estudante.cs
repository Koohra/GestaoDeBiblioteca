using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Estudantes
{
    public class Estudante : IUsuario
    {
        public int Matricula { get; private set; }
        public string? Curso { get; set; }
        public int AnoDeIngresso { get; set; }
        public bool LivroEmprestado { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void PesquisarLivro(string livroBuscado)
        {
            throw new NotImplementedException();

            /*string arquivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dados", "LivrosAcervo.json");

            try
            {
                string json = File.ReadAllText(arquivoJson);
                JArray livros = JArray.Parse(json);

                foreach (var livro in livros)
                {
                    if (livro["titulo"].ToString().Equals(livroBuscado, StringComparison.OrdinalIgnoreCase))
                    {
                        // exibir livro, aonde está informação de disponível?
                        WriteLine($"Título: {livro["titulo"]}");
                        WriteLine($"Autor: {livro["autor"]}");
                        WriteLine($"Ano de Publicação: {livro["anoPublicacao"]}");
                        WriteLine($"Exemplares Disponíveis: {livro["exemplares"]}");
                        WriteLine($"Setor: {livro["setor"]}");
                        WriteLine($"Lista de Reserva: {livro["listaDeReserva"]}");
                        return;
                    }
                }
                WriteLine($"Livro '{livroBuscado}' não encontrado no acervo.");
            }
            catch (Exception ex)
            {
                WriteLine($"Erro ao pesquisar livro: {ex.Message}");
            }*/
        }
    }
}