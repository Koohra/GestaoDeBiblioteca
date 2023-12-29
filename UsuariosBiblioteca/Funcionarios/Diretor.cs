using Newtonsoft.Json;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Funcionarios
{
    public class Diretor : Funcionario
    {

        public Diretor(string codigoCadastro, string nome, string email, string senha) : base(codigoCadastro, nome, email, senha) {
            Cargo = Cargos.Diretor;
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void PesquisarLivro(string livroBuscado)
        {
            throw new NotImplementedException();
        }

        public static void AdicionarFuncionario(FuncionarioService instanciaFuncionarioService, Funcionario novoFuncionario)
        {
            instanciaFuncionarioService.AdicionarNovoFuncionario(novoFuncionario);
        }

    }
}
