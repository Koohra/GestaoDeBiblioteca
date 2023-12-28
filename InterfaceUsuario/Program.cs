using SistemaBiblioteca.Dados;
using UsuariosBiblioteca.Professores;

namespace InterfaceUsuario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Professor>? professores = new List<Professor>();

            var ManipularProfessor = new ManipularJasonProfessor();
            professores = ManipularProfessor.LerJsonProfessores();


            // Agora você tem uma lista de objetos para utilizar
            foreach (var professor in professores)
            {
                Console.WriteLine($"Código de Cadastro: {professor.CodigoCadastro}\n" +
                    $"Nome: {professor.Nome}\nE-mail: {professor.Email}\n" +
                    $"Proxima alteração de senha: {professor.ProximaAlteracaoDeSenha}");
                Console.WriteLine();
            }
        }
    }
}
