using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosBiblioteca.Estudantes;

namespace UserInterface
{
    internal static class InterfaceEstudante
    {
        internal static void MenuEstudante()
        {
            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("1- Pesquisar Livro\n2- Reservar Livro\n3- Logout");

            int acao;
            while (!int.TryParse(Console.ReadLine(), out acao))
            {
                Console.Write("Digite o número correspondente a ação");
            }

            switch (acao)
            {
                case 1:
                    //Estudante.PesquisarLivro();
                    return;
                case 2:
                    //Função de reservar livro;
                    return;
                case 3:
                    //Estudante.Logout();
                    return;
                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    return;
            }
        }
    }
}
