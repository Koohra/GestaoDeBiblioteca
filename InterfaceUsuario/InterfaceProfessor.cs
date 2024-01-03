using ControleDoAcervo.Livros;
using ControleDoAcervo.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosBiblioteca.Professores;

namespace SistemaBiblioteca
{
    internal class InterfaceProfessor
    {
        internal static void MenuProfessor(Professor professorLogado)
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
                    professorLogado.PesquisarLivro();
                    MenuProfessor(professorLogado);
                    return;
                  
                case 2:
                    int idLivro;

                    Console.WriteLine("Digite o ID do livro que deseja reservar:");
                    while (!int.TryParse(Console.ReadLine(), out idLivro))
                    {
                        Console.Write("Número inválido, digite de novo: ");
                    }

                    LivroService livroService = new LivroService();
                    Livro livroReservar = livroService.LerLivroPorID(idLivro);
                    Reserva reserva = livroReservar.AdicionarReserva(professorLogado.CodigoCadastro);
                    reserva.ExibirInformacoes();
                    livroService.AlterarLivroPorID(livroReservar.Id, livroReservar);
                    MenuProfessor(professorLogado);
                    return;
                case 3:
                    professorLogado.Logout();
                    FazerLogin.EscolherUsuario();
                    return;
                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    MenuProfessor(professorLogado);
                    return;
            }
        }
    }
}
