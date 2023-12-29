using Newtonsoft.Json;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Funcionarios
{
    public class Diretor : Funcionario
    {

        public Diretor(string codigoCadastro, string nome, string email, string senha) : base(codigoCadastro, nome, email, senha) {
            Cargo = Cargos.Diretor;
        }


        public static void AdicionarFuncionario(FuncionarioService instanciaFuncionarioService, Funcionario novoFuncionario)
        {
            instanciaFuncionarioService.AdicionarNovoFuncionario(novoFuncionario);
        }

    }
}
