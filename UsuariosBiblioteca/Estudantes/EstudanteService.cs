using Newtonsoft.Json;

namespace UsuariosBiblioteca.Estudantes
{
    internal class EstudanteService
    {
        public string? Caminho { get; set; }

        public EstudanteService(string? arquivoJson = "ListaDeEstudantes.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dados", arquivoJson);
            Caminho = Caminho.Replace("bin\\Debug\\net8.0\\", "");
        }

        public List<Estudante>? LerJsonEstudantes()
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    var conteudoJson = File.ReadAllText(Caminho);
                    List<Estudante>? estudantes = JsonConvert.DeserializeObject<List<Estudante>>(conteudoJson);
                    return estudantes;
                }
                else
                {
                    Console.WriteLine("O arquivo json não foi encontrado");
                    return new List<Estudante>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler o json de Estudantes: {e}");
                return new List<Estudante>();
            }
        }
    }
}