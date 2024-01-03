using Newtonsoft.Json;
using UsuariosBiblioteca.Professores;

namespace UsuariosBiblioteca.Estudantes
{
    public class EstudanteService
    {
        public string? Caminho { get; set; }

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


        //public void AlterarProfessorPorCodigo(string matricula, string nome, string email, string curso)
        //{
        //    try
        //    {
        //        List<Estudante>? estudantes = LerJsonEstudantes();
        //        Estudante? estudanteParaAtualizar = estudantes.FirstOrDefault(estudante => estudante.Matricula == matricula);

        //        if (estudanteParaAtualizar != null)
        //        {
        //            estudanteParaAtualizar.Nome = nome;
        //            estudanteParaAtualizar.Email = email;
        //            estudanteParaAtualizar.Curso = curso;

        //            //SalvarJsonProfessores(professores);

        //            Console.WriteLine($"Estudante com matricula {Matricula} atualizado com sucesso.");
        //            estudanteParaAtualizar.ExibirInformacoes();
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Professor com código {Matricula} não foi encontrado.");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"Não foi possível alterar o professor com código {Matricula}: {e}");
        //    }
        //}

    }
}