using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UsuariosBiblioteca.Funcionarios;


public class FuncionarioService
{
    private string arquivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Funcionarios", "ListaDosFuncionarios.json");
    private List<Funcionario> listaFuncionarios;

    public FuncionarioService()
    {
        arquivoJson = arquivoJson.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "UsuariosBiblioteca");
        listaFuncionarios = InicializarFuncionarios();
    }

    private List<Funcionario> InicializarFuncionarios()
    {
        try
        {
            string json = File.ReadAllText(arquivoJson);
            Funcionario[] arrayFuncionarios = JsonConvert.DeserializeObject<Funcionario[]>(json);
            return new List<Funcionario>(arrayFuncionarios);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro na inicialização dos funcionários: " + ex.Message);
            return new List<Funcionario>();
        }
    }

    public void DetalhesDoUsuario()
    {
        try
        {
            foreach (var funcionario in listaFuncionarios)
            {
                funcionario.ExibirInformacoes();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao exibir os detalhes dos funcionários: " + ex.Message);
        }
    }

    public void AdicionarNovoFuncionario(Funcionario novoFuncionario)
    {
        listaFuncionarios.Add(novoFuncionario);

        string novoJson = JsonConvert.SerializeObject(listaFuncionarios, Formatting.Indented);
        File.WriteAllText(arquivoJson, novoJson);

        Console.WriteLine("Novo funcionário adicionado com sucesso!");
    }
}


