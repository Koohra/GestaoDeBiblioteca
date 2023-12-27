using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Funcionarios
{
    internal class Diretor : IUsuario
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }

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
        
        public static void AdicionarFuncionario(ManipularJsonFuncionario manipularJson, Funcionario novoFuncionario)
        {
            manipularJson.AdicionarNovoFuncionario(novoFuncionario);
        }
    }
}
