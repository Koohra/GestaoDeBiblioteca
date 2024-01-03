using ControleDoAcervo.Livros;
using System.Text.Json.Serialization;
using UsuariosBiblioteca.Estudantes;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Funcionarios
{
    public class Funcionario : IUsuario
    {
        public string? CodigoCadastro { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public Cargos Cargo { get; set; }
        public string? Senha { get; set; }



        public Funcionario() { }

        public Funcionario(string codigoCadastro, string nome, string email, string senha)
        {
            CodigoCadastro = codigoCadastro;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        public Funcionario(string codigoCadastro, string nome, string email, Cargos cargo, string senha)
        {
            CodigoCadastro = codigoCadastro;
            Nome = nome;
            Email = email;
            Cargo = cargo;
            Senha = senha;
        }
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Codigo cadastro: {CodigoCadastro}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Email: {Email} ");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine();
        }

        public void VerificarStatusLivro(Livro livro)
        {
            // AcervoBiblioteca.VerificarDisponibilidade(livro);
            // Aguardando método estar pronto
        }

        public void CadastrarLivro(string titulo, string autor, int anoPublicacao, Dictionary<EstadoExemplar, int> exemplares)
        {
            // Aguardando método estar pronto
        }

        public void AtualizarNumeroLivros()
        {
            // Aguardando método estar pronto
        }

        public void PesquisarLivro(string livroBuscado)
        {
            // Aguardando método estar pronto
        }

        public IUsuario? Login()
        {
            FuncionarioService funcionarioService = new FuncionarioService();
            List<Funcionario> listaFuncionarios = funcionarioService.RetornarLista();

            Console.WriteLine("Código de cadastro:");
            string codigoCadastro = Console.ReadLine()!;
            Console.WriteLine("Senha:");
            string senha = Console.ReadLine()!;

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                if (funcionario.CodigoCadastro == codigoCadastro && funcionario.Senha == senha)
                {
                    return funcionario;
                }
            }

            Console.WriteLine("Código de cadastro ou senha incorreta. Tentar novamente? Digite 'S' para tentar novamente");
            char continuar = Console.ReadKey().KeyChar;
            Console.WriteLine("");

            if (continuar == 'S' || continuar == 's')
            {
                Login();
            }

            return null;

        }

        void IUsuario.Logout()
        {
            Console.Clear();
            Console.WriteLine($"Usuário desconectado.");
        }

        void IUsuario.PesquisarLivro()
        {
            throw new NotImplementedException();
        }

        public static Funcionario LocalizarPorCodigo()
        {
            FuncionarioService funcionarioService = new FuncionarioService();
            List<Funcionario> listaFuncionarios = funcionarioService.RetornarLista();

            Console.WriteLine("Código de cadastro:");
            string codigoCadastro = Console.ReadLine()!;

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                if (funcionario.CodigoCadastro == codigoCadastro)
                {
                    return funcionario;
                }
            }
            return null;
        }

        public Cargos MudarCargo()
        {
            Cargos novocargo;
            Console.WriteLine("Cargo:");
            Console.WriteLine("1- Atendente\n2- Bibliotecario\n3- Diretor");
            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Write("Digite o número correspondente;");
            }
            switch (opcao)
            {
                case 1:
                    novocargo = Cargos.Atendente;
                    return novocargo;
                case 2:
                    novocargo = Cargos.Bibliotecario;
                    return novocargo;
                case 3:
                    novocargo = Cargos.Diretor;
                    return novocargo;
                default:
                    Console.Write("Entrada não identificada, sera mantido o cargo atual;");
                    novocargo = Cargo;
                    return novocargo;
            }
        }


    }
}

