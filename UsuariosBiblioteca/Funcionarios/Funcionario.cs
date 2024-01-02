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

        public IUsuario Login()
        {
            FuncionarioService funcionarioService = new FuncionarioService();
            List<Funcionario> listaFuncionarios = funcionarioService.RetornarLista();

            while (true)
            {
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
                Console.WriteLine("Código de cadastro ou senha incorreta. O que deseja fazer?");
                Console.WriteLine("1- Tentar novamente\n2- Voltar ao menu principal\n3- Sair");

                int opcao;
                while (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.Write("Digite o número correspondente à sua escolha: ");
                }

                switch (opcao)
                {
                    case 1:
                        break;
                    case 2:
                        Console.Clear();
                        return null;
                    case 3:
                        Console.WriteLine("Obrigado por usar nossos serviços. Até mais!");
                        Environment.Exit(0);
                        return null;
                    default:
                        Console.WriteLine("Número digitado não corresponde a nenhuma das opções.");
                        break;
                }
            }
        }

        void IUsuario.Logout()
        {
            Console.Clear();
            Console.WriteLine($"Usuário desconectado.");
        }

        void IUsuario.PesquisarLivro(string livroBuscado)
        {
            throw new NotImplementedException();
        }
    }
}
