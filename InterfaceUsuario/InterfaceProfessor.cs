using ControleDoAcervo.Livros;
using UsuariosBiblioteca.Professores;

namespace SistemaBiblioteca
{
    internal class InterfaceProfessor
    {
        internal static void MenuProfessor(Professor professorLogado)
        {
            Console.Clear();
            Console.WriteLine($"Logado como professor {professorLogado.Nome}");

            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("1- Pesquisar Livro\n2- Reservar Livro\n3- Logout");

            int acao;
            while (!int.TryParse(Console.ReadLine(), out acao))
                Console.Write("Digite o número correspondente a ação");

            switch (acao)
            {
                case 1:
                    professorLogado.PesquisarLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuProfessor(professorLogado);
                    return;
                  
                case 2:
                    int idLivro;

                    Console.WriteLine("Digite o ID do livro que deseja reservar:");
                    while (!int.TryParse(Console.ReadLine(), out idLivro))
                    {
                        Console.Write("Número inválido, digite de novo: ");
                    }
                    string codigoCadastro = professorLogado.CodigoCadastro!;
                    LivroService livroService = new();
                    livroService.ReservarLivro(idLivro, codigoCadastro);

                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
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
