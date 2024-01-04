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
            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("1- Liberar Empréstimo \n2- Receber Livro \n3- Verificar Livro \n4- Cadastrar Livro \n5- Atualizar Livro \n6- Atualizar dados de Usuário");

            int acao;
            while (!int.TryParse(Console.ReadLine(), out acao))
            {
                Console.Write("Digite o número correspondente a ação");
            }

            switch (acao)
            {
                case 1:
                    atendente.PermitirEmprestimo();
                    MenuAtendente(atendente);
                    return;

                case 2:
                    atendente.ReceberDevolucao();
                    MenuAtendente(atendente);
                    return;

                case 3:
                    atendente.VerificarStatusLivro();
                    MenuAtendente(atendente);
                    return;

                case 4:
                    atendente.CadastrarLivro();
                    MenuAtendente(atendente);
                    return;

                case 5:
                    atendente.AtualizarNumeroLivros();
                    MenuAtendente(atendente);
                    return;

                case 6:
                    atendente.AtualizarRegistroUsuario();
                    MenuAtendente(atendente);
                    return;

                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    MenuAtendente(atendente);
                    return;
            }
        }

        internal static void MenuDiretor(Diretor diretor)
        {
            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("\n1- Cadastrar funcionário \n2- Verificar Livro \n3- Cadastrar Livro \n4- Atualizar Livro");

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
                    MenuDiretor(diretor);
                    return;

                case 2:
                    diretor.VerificarStatusLivro();
                    MenuDiretor(diretor);
                    return;

                case 3:
                    diretor.CadastrarLivro();
                    MenuDiretor(diretor);
                    return;

                case 4:
                    diretor.AtualizarNumeroLivros();
                    MenuDiretor(diretor);
                    return;

                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    return;
            }
        }

        internal static void MenuBibliotecario(Bibliotecario bibliotecario) //receber Bibliotecario bibliotecario
        {
            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("1- Verificar Livro \n2- Cadastrar Livro \n3- Atualizar Livro");

            int acao;
            while (!int.TryParse(Console.ReadLine(), out acao))
            {
                Console.Write("Digite o número correspondente a ação");
            }

            switch (acao)
            {
                case 1:
                    bibliotecario.VerificarStatusLivro();
                    MenuBibliotecario(bibliotecario);
                    return;

                case 2:
                    bibliotecario.CadastrarLivro();
                    MenuBibliotecario(bibliotecario);
                    return;

                case 3:
                    bibliotecario.AtualizarNumeroLivros();
                    MenuBibliotecario(bibliotecario);
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
            string codigo = funcionario.CodigoCadastro;
            string nome = funcionario.Nome;
            string email = funcionario.Email;
            string senha = funcionario.Senha;

            Atendente atendente = new Atendente(codigo, nome, email, senha);
            return atendente;
        }

        public static Diretor TransformarDiretor(Funcionario funcionario)
        {
            string codigo = funcionario.CodigoCadastro;
            string nome = funcionario.Nome;
            string email = funcionario.Email;
            string senha = funcionario.Senha;

            Diretor diretor = new Diretor(codigo, nome, email, senha);
            return diretor;
        }

        public static Bibliotecario TransformarBibliotecario(Funcionario funcionario) 
        {
            string codigo = funcionario.CodigoCadastro;
            string nome = funcionario.Nome;
            string email = funcionario.Email;
            string senha = funcionario.Senha;

            Bibliotecario bibliotecario = new Bibliotecario(codigo, nome, email, senha);
            return bibliotecario;
        }

    }
}
