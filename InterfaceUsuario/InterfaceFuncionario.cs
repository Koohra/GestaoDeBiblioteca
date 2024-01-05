using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosBiblioteca.Funcionarios;

namespace SistemaBiblioteca
{
    internal class InterfaceFuncionario
    {
        internal static void MenuAtendente(Atendente atendente)
        {
            Console.Clear();
            Console.WriteLine($"Logado como {atendente.Cargo} {atendente.Nome}");

            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("1- Liberar Empréstimo \n2- Receber Livro \n3- Pesquisar livros \n4- Verificar Livro \n5- Cadastrar Livro " +
                "\n6- Atualizar Livro \n7- Atualizar dados de Usuário \n8- Logout");

            int acao;
            while (!int.TryParse(Console.ReadLine(), out acao))
            {
                Console.Write("Digite o número correspondente a ação");
            }

            switch (acao)
            {
                case 1:
                    atendente.PermitirEmprestimo();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuAtendente(atendente);
                    return;

                case 2:
                    atendente.ReceberDevolucao();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuAtendente(atendente);
                    return;

                case 3:
                    atendente.PesquisarLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuAtendente(atendente);
                    return;

                case 4:
                    atendente.VerificarStatusLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuAtendente(atendente);
                    return;

                case 5:
                    atendente.CadastrarLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuAtendente(atendente);
                    return;

                case 6:
                    atendente.AtualizarNumeroLivros();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuAtendente(atendente);
                    return;

                case 7:
                    atendente.AtualizarRegistroUsuario();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuAtendente(atendente);
                    return;

                case 8:
                    atendente.Logout();
                    FazerLogin.EscolherUsuario();
                    return;

                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    MenuAtendente(atendente);
                    return;
            }
        }

        internal static void MenuDiretor(Diretor diretor)
        {
            Console.Clear();
            Console.WriteLine($"Logado como {diretor.Cargo} {diretor.Nome}");

            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("\n1- Cadastrar funcionário \n2- Pesquisar livros \n3- Verificar Livro \n4- Cadastrar Livro \n5- Atualizar Livro \n6- Logout");

            int acao;
            while (!int.TryParse(Console.ReadLine(), out acao))
            {
                Console.Write("Digite o número correspondente a ação");
            }

            switch (acao)
            {
                case 1:
                    Funcionario funcionario = CriarFuncionario();
                    FuncionarioService funcionarioService = new FuncionarioService();
                    Diretor.AdicionarFuncionario(funcionarioService, funcionario);
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuDiretor(diretor);
                    return;

                case 2:
                    diretor.PesquisarLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuDiretor(diretor);
                    return;

                case 3:
                    diretor.VerificarStatusLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuDiretor(diretor);
                    return;

                case 4:
                    diretor.CadastrarLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuDiretor(diretor);
                    return;

                case 5:
                    diretor.AtualizarNumeroLivros();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuDiretor(diretor);
                    return;

                case 6:
                    diretor.Logout();
                    FazerLogin.EscolherUsuario();
                    return;

                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    return;
            }
        }

        internal static void MenuBibliotecario(Bibliotecario bibliotecario)
        {
            Console.Clear();
            Console.WriteLine($"Logado como {bibliotecario.Cargo} {bibliotecario.Nome}");

            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("1- Pesquisar Livro \n2- Verificar Livro \n3- Cadastrar Livro \n4- Atualizar Livro \n5- Logout");

            int acao;
            while (!int.TryParse(Console.ReadLine(), out acao))
            {
                Console.Write("Digite o número correspondente a ação");
            }

            switch (acao)
            {
                case 1:
                    bibliotecario.PesquisarLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuBibliotecario(bibliotecario);
                    return;

                case 2:
                    bibliotecario.VerificarStatusLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuBibliotecario(bibliotecario);
                    return;

                case 3:
                    bibliotecario.CadastrarLivro();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuBibliotecario(bibliotecario);
                    return;

                case 4:
                    bibliotecario.AtualizarNumeroLivros();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuBibliotecario(bibliotecario);
                    return;

                case 5:
                    bibliotecario.Logout();
                    FazerLogin.EscolherUsuario();
                    return;

                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    MenuBibliotecario(bibliotecario);
                    return;
            }
        }

        internal static Funcionario CriarFuncionario()
        {
            Console.WriteLine("Codigo: ");
            string codigo = Console.ReadLine()!;
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Email: ");
            string email = Console.ReadLine()!;
            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine()!;
            Cargos cargo = Funcionario.SelecionarCargo();

            Funcionario funcionario = new Funcionario(codigo, nome, email, cargo, senha);
            return funcionario;
        }

        public static Atendente TransformarAtendente(Funcionario funcionario)
        {
            string? codigo = funcionario.CodigoCadastro;
            string? nome = funcionario.Nome;
            string? email = funcionario.Email;
            string? senha = funcionario.Senha;

            Atendente atendente = new Atendente(codigo, nome, email, senha);
            return atendente;
        }

        public static Diretor TransformarDiretor(Funcionario funcionario)
        {
            string? codigo = funcionario.CodigoCadastro;
            string? nome = funcionario.Nome;
            string? email = funcionario.Email;
            string? senha = funcionario.Senha;

            Diretor diretor = new Diretor(codigo, nome, email, senha);
            return diretor;
        }

        public static Bibliotecario TransformarBibliotecario(Funcionario funcionario) 
        {
            string? codigo = funcionario.CodigoCadastro;
            string? nome = funcionario.Nome;
            string? email = funcionario.Email;
            string? senha = funcionario.Senha;

            Bibliotecario bibliotecario = new Bibliotecario(codigo, nome, email, senha);
            return bibliotecario;
        }

    }
}
