using ControleDoAcervo.Livros;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UsuariosBiblioteca.Professores;

namespace UsuariosBiblioteca.Estudantes
{
    public class EstudanteService
    {
        public string? Caminho { get; set; }
        public List<Estudante> Estudantes { get; private set; } = new List<Estudante>();

        public EstudanteService(string? arquivoJson = "ListaDeEstudantes.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Estudantes", arquivoJson);
            Caminho = Caminho.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "UsuariosBiblioteca");
        }

        public List<Estudante>? LerJsonEstudantes()
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    var conteudoJson = File.ReadAllText(Caminho);
                    JArray estudantesJSON = JArray.Parse(conteudoJson);

                    foreach (var estudanteJSON in estudantesJSON)
                    {
                        Estudante? estudante = JsonConvert.DeserializeObject<Estudante?>(estudanteJSON.ToString());
                        if (estudante != null)
                            Estudantes.Add(estudante);
                    }
                }
                else
                {
                    Console.WriteLine("O arquivo json não foi encontrado");
                }
                
                return Estudantes;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler o json de Estudantes: {e}");
                return new List<Estudante>();
            }
        }

        public void SalvarJsonEstudantes(List<Professor> estudantes)
        {

            try
            {
                if (File.Exists(Caminho)) // conferir se vai dar erro
                {
                    // Serializa a lista de professores de volta para o formato JSON
                    string json = JsonConvert.SerializeObject(estudantes, Formatting.Indented);

                    // Escreve o JSON de volta no arquivo
                    File.WriteAllText(Caminho, json);

                    Console.WriteLine("Alterações salvas com sucesso no arquivo JSON.");
                }
                else
                {
                    Console.WriteLine("Não foi encontrado nenhum arquivo JSON para ser atualizado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao tentar salvar as alterações no arquivo JSON: " + e.Message);
            }
        }
    }
}