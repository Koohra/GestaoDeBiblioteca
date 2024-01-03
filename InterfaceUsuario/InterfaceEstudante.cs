using ControleDoAcervo.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosBiblioteca.Estudantes;

namespace SistemaBiblioteca
{
    internal static class InterfaceEstudante
    {
        public static void MenuEstudante(Estudante estudanteLogado)
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
                    estudanteLogado.PesquisarLivro();
                    return;

                case 2:
                    int idLivro;

                    Console.WriteLine("Digite o Id do livro que você deseja reservar:");
                    while (!int.TryParse(Console.ReadLine(), out idLivro))
                    {
                        Console.Write("Número inválido, digite de novo: ");
                    }

                    LivroService livroService = new LivroService();
                    Livro livroReservar = livroService.LerLivroPorID(idLivro);
                    livroReservar.AdicionarReserva(estudanteLogado.Matricula.ToString());
                    livroService.AlterarLivroPorID(livroReservar.Id, livroReservar);
                    return;

                case 3:
                    estudanteLogado.Logout();
                    FazerLogin.EscolherUsuario();
                    return;
                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    return;
            }
        }
    }
}
