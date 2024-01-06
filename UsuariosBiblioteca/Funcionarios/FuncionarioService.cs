using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UsuariosBiblioteca.Funcionarios;
using UsuariosBiblioteca.Professores;


public class FuncionarioService
{
    private string CaminhoJSON {  get; set; }
    private List<Funcionario>? Funcionarios { get; set; } = [];

    public FuncionarioService()
    {
        CaminhoJSON = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Funcionarios", "ListaDosFuncionarios.json");
        CaminhoJSON = CaminhoJSON.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "UsuariosBiblioteca");
        Funcionarios = LerJSONFuncionarios();
    }
    public List<Funcionario>? LerJSONFuncionarios()
    {
        try
        {
            string conteudoJSON = File.ReadAllText(CaminhoJSON);
            Funcionarios = JsonConvert.DeserializeObject<List<Funcionario>?>(conteudoJSON);
            return Funcionarios;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro na inicialização dos funcionários: " + ex.Message);
            return null;
        }
    }

    public void SalvarJSONFuncionarios(List<Funcionario> listaFuncionarios)
    {
        try
        {
            if (File.Exists(CaminhoJSON))
            {
                string json = JsonConvert.SerializeObject(listaFuncionarios, Formatting.Indented);
                File.WriteAllText(CaminhoJSON, json);
                Console.WriteLine("Alterações salvas com sucesso no arquivo JSON.");
            }
            else
                Console.WriteLine("Não foi encontrado nenhum arquivo JSON para ser atualizado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao tentar salvar as alterações no arquivo JSON: {ex}");
        }
    }

    public void DetalhesDoUsuario()
    {
        try
        {
            foreach (var funcionario in Funcionarios!)
            {
                funcionario.ExibirInformacoes();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao exibir os detalhes dos funcionários: {ex}");
        }
    }

    public void AdicionarNovoFuncionario(Funcionario novoFuncionario)
    {
        try
        {
            Funcionarios?.Add(novoFuncionario);
            string novoJson = JsonConvert.SerializeObject(Funcionarios, Formatting.Indented);
            File.WriteAllText(CaminhoJSON, novoJson);

            Console.WriteLine("Novo funcionário adicionado com sucesso!");
        } catch(Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao adicionar um novo funcionário: {ex}");
        }
    }

    public void AlterarFuncionarioPorCodigo(string CodigoCadastro, string nome, string email, Cargos cargo, string senha)
    {
        try
        {
            List<Funcionario>? funcionarios = LerJSONFuncionarios();
            Funcionario? funcionarioParaAtualizar = funcionarios?.FirstOrDefault(funcionario => funcionario.CodigoCadastro == CodigoCadastro);

            if (funcionarioParaAtualizar != null)
            {
                funcionarioParaAtualizar.Nome = nome;
                funcionarioParaAtualizar.Email = email;
                funcionarioParaAtualizar.Cargo = cargo;
                funcionarioParaAtualizar.Senha = senha;

                SalvarJSONFuncionarios(funcionarios!);

                Console.WriteLine($"Funcionário com código {CodigoCadastro} atualizado com sucesso.");
                funcionarioParaAtualizar.ExibirInformacoes();
            }
            else
                Console.WriteLine($"Funcionário com código {CodigoCadastro} não foi encontrado.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Não foi possível alterar o funcionário com código {CodigoCadastro}: {e}");
        }
    }
}
