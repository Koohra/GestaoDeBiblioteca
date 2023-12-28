using Newtonsoft.Json;
using UsuariosBiblioteca.Estudantes;



namespace SistemaBiblioteca.Dados
{
    internal class ManipularJsonEstudantes
    {
        public string? Caminho { get; set; }



        public string EstudanteService(string arquivoJson = "ListaDeEstudantes.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dados", arquivoJson);
            Caminho = Caminho.Replace("bin\\Debug\\net8.0\\", "");
            return Caminho;

        }

        public List<Estudante>? LerJsonEstudantes()
        {
            try
            {
                if (File.Exists(EstudanteService()))
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