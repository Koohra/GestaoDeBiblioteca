using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UsuariosBiblioteca.Funcionarios;


public class ManipularJsonFuncionario
{
    private string arquivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dados", "ListaDosFuncionarios.json");
    private List<Funcionario> listaFuncionarios;

    public ManipularJsonFuncionario()
    {
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

    public void DetalhesdoUsuario()
    {
        try
        {
            foreach (var funcionario in listaFuncionarios)
            {
                Console.WriteLine("Codigo cadastro: " + funcionario.CodigoCadastro);
                Console.WriteLine("Nome: " + funcionario.Nome);
                Console.WriteLine("Email: " + funcionario.Email);
                Console.WriteLine("Cargo: " + funcionario.Cargo);
                Console.WriteLine();
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


