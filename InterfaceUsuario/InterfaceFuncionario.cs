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
            Console.WriteLine("1- Liberar Empréstimo \n2- Verificar Livro \n3- Cadastrar Livro \n4- Atualizar Livro \n5- Atualizar dados de Usuário");

            int acao;
            while (!int.TryParse(Console.ReadLine(), out acao))
            {
                Console.Write("Digite o número correspondente a ação");
            }

            switch (acao)
            {
                case 1:
                    //atendente.LiberarEmprestimo(); precisa adicionar em atendente implementado
                    return;
                case 2:
                    //atendente.PesquisarLivro(); esta duplicado em funcionario e atendente
                    return;
                case 3:
                    //atendente.CadastrarLivro();
                    return;
                case 4:
                    //atendente.AtualizarNumeroLivros();
                    return;
                case 5:
                    atendente.AtualizarRegistroUsuario();
                    MenuAtendente(atendente);
                    return;
                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    return;
            }
        }

        internal static void MenuDiretor(Diretor diretor) //receber Diretor diretor
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
                    return;
                case 2:
                    //atendente.PesquisarLivro(); esta duplicado em funcionario e atendente
                    return;
                case 3:
                    //diretor.CadastrarLivro();
                    return;
                case 4:
                    //diretor.AtualizarNumeroLivros();
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
                    //bibliotecario.PesquisarLivro(); esta duplicado em funcionario e atendente
                    return;
                case 2:
                    //bibliotecario.CadastrarLivro();
                    return;
                case 3:
                    //bibliotecario.AtualizarNumeroLivros();
                    return;
                default:
                    Console.WriteLine("Número digitado não corresponde a nenhuma das opções");
                    return;
            }
        }

        internal static Funcionario CriarFuncionario()
        {
            Console.WriteLine("Codigo: ");
            string codigo = Console.ReadLine()!;
            string nome = Console.ReadLine()!;
            string email = Console.ReadLine()!;
            string senha = Console.ReadLine()!;

            Funcionario funcionario = new Funcionario(codigo, nome, email, Cargos.Bibliotecario, "abc");
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
