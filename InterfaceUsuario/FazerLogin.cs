using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosBiblioteca.Estudantes;
using UsuariosBiblioteca.Funcionarios;

namespace SistemaBiblioteca
{
    internal static class FazerLogin
    {
        internal static void EscolherUsuario()
        {
            Console.WriteLine("Selecione login desejado:");
            Console.WriteLine("1- Estudante\n2- Professor\n3-Funcionário");
            Console.WriteLine();
            Console.WriteLine("\nOu digite 4 para SAIR");
            int usuario;
            while (!int.TryParse(Console.ReadLine(), out usuario))
            {
                Console.Write("Digite o número correspondente ao seu login");
            }

            switch (usuario)
            {
                case 1:
                    Console.WriteLine("\nLOGIN DE ESTUDANTE");
                    if (LoginEstudante())
                    {
                        InterfaceEstudante.MenuEstudante();
                    }
                    return;

                case 2:
                    Console.WriteLine("\nLOGIN DE PROFESSOR");
                    //Professor professor = Professor.Login();
                    InterfaceProfessor.MenuProfessor(); //passando um professor
                    return;
                case 3:
                    Console.WriteLine("\nLOGIN DE FUNCIONÁRIO");
                    Console.WriteLine("Código de cadastro:");
                    string codigoCadastro = Console.ReadLine()!;
                    Console.WriteLine("Senha:");
                    string senha = Console.ReadLine()!;
                    Funcionario funcionario = Funcionario.Login(codigoCadastro, senha);

                    Console.WriteLine($"Logado como {funcionario.Nome}");
                    if (funcionario.Cargo == Cargos.Atendente)
                    {
                        Atendente atendente = InterfaceFuncionario.TransformarAtentende(funcionario);
                        InterfaceFuncionario.MenuAtendente(atendente);
                    } else if (funcionario.Cargo == Cargos.Bibliotecario)
                    {
                        //InterfaceFuncionario.MenuBibliotecario(funcionario);
                    } else
                    {
                        Diretor diretor = InterfaceFuncionario.TransformarDiretor(funcionario);
                        InterfaceFuncionario.MenuDiretor(diretor);
                    }

                    return;
                case 4:
                    Console.WriteLine("Agradecemos por usar nossos serviços. Até mais!");
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    return;
            }
        }
        private static bool LoginEstudante()
        {
            Estudante estudante = new Estudante();
            return estudante.Login();
        }
        
    }
}
