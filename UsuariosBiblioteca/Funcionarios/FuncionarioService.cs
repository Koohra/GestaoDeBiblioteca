using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UsuariosBiblioteca.Funcionarios;
using UsuariosBiblioteca.Professores;


public class FuncionarioService
{
    private string arquivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Funcionarios", "ListaDosFuncionarios.json");
    private List<Funcionario> listaFuncionarios;

    public FuncionarioService()
    {
        arquivoJson = arquivoJson.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "UsuariosBiblioteca");
        listaFuncionarios = InicializarFuncionarios();
    }

    internal List<Funcionario> RetornarLista()
    {
        listaFuncionarios = InicializarFuncionarios();
        return listaFuncionarios;
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

    public void SalvarJsonFuncionarios(List<Funcionario> listaFuncionarios)
    {

        try
        {
            if (File.Exists(arquivoJson)) // conferir se vai dar erro
            {
                // Serializa a lista de professores de volta para o formato JSON
                string json = JsonConvert.SerializeObject(listaFuncionarios, Formatting.Indented);

                // Escreve o JSON de volta no arquivo
                File.WriteAllText(arquivoJson, json);

                Console.WriteLine("Alterações salvas com sucesso no arquivo JSON.");
            }
            else
            {
                Console.WriteLine("Não foi encontrado nenhum arquivo JSON para ser atualizado.");
            }
        }
        catch (Exception ex3)
        {
            Console.WriteLine("Ocorreu um erro ao tentar salvar as alterações no arquivo JSON: " + ex3.Message);
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

    public void AlterarFuncionarioPorCodigo(string CodigoCadastro, string nome, string email, Cargos cargo, string senha)
    {
        try
        {
            List<Funcionario>? funcionarios = InicializarFuncionarios();
            Funcionario? funcionarioParaAtualizar = funcionarios.FirstOrDefault(funcionario => funcionario.CodigoCadastro == CodigoCadastro);

            if (funcionarioParaAtualizar != null)
            {
                funcionarioParaAtualizar.Nome = nome;
                funcionarioParaAtualizar.Email = email;
                funcionarioParaAtualizar.Cargo = cargo;
                funcionarioParaAtualizar.Senha = senha;

                //string novoJson = JsonConvert.SerializeObject(listaFuncionarios, Formatting.Indented);
                //File.WriteAllText(arquivoJson, novoJson);
                SalvarJsonFuncionarios(funcionarios);

                Console.WriteLine($"Funcionário com código {CodigoCadastro} atualizado com sucesso.");
                funcionarioParaAtualizar.ExibirInformacoes();
            }
            else
            {
                Console.WriteLine($"Funcionário com código {CodigoCadastro} não foi encontrado.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Não foi possível alterar o funcionário com código {CodigoCadastro}: {e}");
        }
    }


}


