using SistemaBiblioteca.Dados;
using System.Runtime.CompilerServices;
using UsuariosBiblioteca.Funcionarios;

namespace InterfaceUsuario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManipularJsonFuncionario manipuladorJson = new ManipularJsonFuncionario();
            manipuladorJson.SepararPorCargo();
        }
    }
}
