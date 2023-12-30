﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosBiblioteca.Estudantes;

namespace SistemaBiblioteca
{
    internal static class InterfaceEstudante
    {
        public static void MenuEstudante()
        {
            Estudante estudante = new Estudante();

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
                    Console.WriteLine("Digite o título do livro:");
                    string livroBuscado = Console.ReadLine();

                    if (!string.IsNullOrEmpty(livroBuscado))
                    {
                        estudante.PesquisarLivro(livroBuscado);
                    }
                    else
                    {
                        Console.WriteLine("O título do livro não pode ser vazio.");
                    }
                    return;
                case 2:
                    //Função de reservar livro;
                    return;
                case 3:
                    estudante.Logout();
                    FazerLogin.EscolherUsuario();
                    return;
                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    return;
            }
        }
    }
}
