using ControleDoAcervo.Livros;
using ControleDoAcervo.Reservas;
using UsuariosBiblioteca.Estudantes;
using UsuariosBiblioteca.Funcionarios;

namespace SistemaBiblioteca
{
    internal static class InterfaceEstudante
    {
        public static void MenuEstudante(Estudante estudanteLogado)
        {
            Console.Clear();
            Console.WriteLine($"Logado como {estudanteLogado.Nome} - {estudanteLogado.Matricula}");

            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("1- Pesquisar Livro\n2- Reservar Livro\n3- Logout");

            int acao;
            
            while (!int.TryParse(Console.ReadLine(), out acao) || acao < 1 || acao > 3)
            {
                Console.Write("Digite o número correspondente a ação: ");
            }

            switch (acao)
            {
                case 1:
                    estudanteLogado.PesquisarLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstudante(estudanteLogado);
                    return;

                case 2:
                    int idLivro;

                    Console.WriteLine("Digite o ID do livro que deseja reservar:");
                    while (!int.TryParse(Console.ReadLine(), out idLivro))
                    {
                        Console.Write("Número inválido, digite de novo: ");
                    }
                    string matricula = estudanteLogado.Matricula;
                    LivroService livroService = new LivroService();
                    livroService.ReservarLivro(idLivro, matricula);

                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuEstudante(estudanteLogado);
                    return;

                case 3:
                    estudanteLogado.Logout();
                    FazerLogin.EscolherUsuario();
                    return;

                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    MenuEstudante(estudanteLogado);
                    return;
            }
        }
    }
}
