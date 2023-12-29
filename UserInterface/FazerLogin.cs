using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosBiblioteca.Estudantes;

namespace UserInterface
{
    internal static class FazerLogin
    {
        internal static void EscolherUsuario ()
        {
            Console.WriteLine("Selecione login desejado:");
            Console.WriteLine("1- Estudante\n2- Professor\n3-Funcionário");

            int usuario;
            while (!int.TryParse(Console.ReadLine(), out usuario))
            {
                Console.Write("Digite o número correspondente ao seu login");
            }

                switch (usuario)
            {
                case 1:
                    Console.WriteLine("\nLOGIN DE ESTUDANTE");
                    Console.WriteLine("Insira seu número de matrícula:");
                    int matricula;
                    while (!int.TryParse(Console.ReadLine(), out matricula)) //tentar adicionar condição de n° de caracteres na matricula
                    {
                        Console.Write("Número inválido, digite de novo: ");
                    }
                    //Estudante estudante = Estudante.Login(matricula);
                    Console.WriteLine($"Logado como ...");
                    InterfaceEstudante.MenuEstudante(); //passando um estudante
                    return;

                case 2:
                    Console.WriteLine("\nLOGIN DE PROFESSOR");
                    //Professor professor = Professor.Login();
                    InterfaceProfessor.MenuProfessor(); //passando um professor
                    return;
                case 3:
                    Console.WriteLine("\nLOGIN DE FUNCIONÁRIO");
                    //Como passa um funcionario que pode ser qualquer um?
                    //InterfaceProfessor.MenuFuncionario(); //passando um funcionario
                    return;
                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    return;
            }
        }
    }
}
