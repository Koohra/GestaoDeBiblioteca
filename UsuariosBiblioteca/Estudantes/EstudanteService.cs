using ControleDoAcervo.Livros;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UsuariosBiblioteca.Professores;

namespace UsuariosBiblioteca.Estudantes
{
    public class EstudanteService
    {
        private string? Caminho { get; set; }
        public List<Estudante> Estudantes { get; private set; } = [];

        public EstudanteService(string? arquivoJson = "ListaDeEstudantes.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Estudantes", arquivoJson);
            Caminho = Caminho.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "UsuariosBiblioteca");
        }

        public List<Estudante>? LerJSONEstudantes()
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
                    Console.WriteLine("O arquivo JSON não foi encontrado.");
                }
                
                return Estudantes;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler o JSON de Estudantes: {e}");
                return null;
            }
        }

        public void SalvarJSONEstudantes(List<Estudante> estudantes)
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    string json = JsonConvert.SerializeObject(estudantes, Formatting.Indented);
                    File.WriteAllText(Caminho, json);
                    Console.WriteLine("Alterações salvas com sucesso no arquivo JSON.");
                }
                else
                    Console.WriteLine("Não foi encontrado nenhum arquivo JSON para ser atualizado.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao tentar salvar as alterações no arquivo JSON: {e} ");
            }
        }

        public void AlterarEstudantePorMatricula(string Matricula, string nome, string email, string curso)
        {
            try
            {
                List<Estudante>? estudantes = LerJSONEstudantes();
                Estudante? estudanteParaAtualizar = estudantes.FirstOrDefault(estudante => estudante.Matricula == Matricula);

                if (estudanteParaAtualizar != null)
                {
                    estudanteParaAtualizar.Nome = nome;
                    estudanteParaAtualizar.Email = email;
                    estudanteParaAtualizar.Curso = curso;

                    SalvarJSONEstudantes(estudantes);

                    Console.WriteLine($"Estudante com a matrícula {Matricula} atualizado com sucesso.");
                    estudanteParaAtualizar.ExibirInformacoes();
                }
                else
                    Console.WriteLine($"Estudante com a matrícula {Matricula} não foi encontrado.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível alterar o estudante com a matrícula {Matricula}: {e}");
            }
        }
    }
}