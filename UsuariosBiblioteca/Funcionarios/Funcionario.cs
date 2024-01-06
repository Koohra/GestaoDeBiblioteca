using ControleDoAcervo;
using ControleDoAcervo.Livros;
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

        private static string LerSenha()
        {
            string senha = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    senha += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
                {
                    senha = senha.Substring(0, senha.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return senha;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Codigo cadastro: {CodigoCadastro}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Email: {Email} ");
            Console.WriteLine($"Cargo: {Cargo}\n");
        }

        public static void VerificarStatusLivro()
        {
            Console.Write("Digite o ID do livro: ");
            int idLivro;

            while (!int.TryParse(Console.ReadLine(), out idLivro))
                Console.Write("Número inválido, digite de novo: ");

            LivroService livroService = new();
            Livro? livro = livroService.LerLivroPorID(idLivro);

            if (livro != null)
                livro.ExibirInformacoes();
        }

        public static void CadastrarLivro()
        {
            AcervoBiblioteca.AdicionarLivro();
        }

        public static void AtualizarNumeroLivros()
        {
            Console.Write("Digite o ID do livro: ");
            int idLivro;

            while (!int.TryParse(Console.ReadLine(), out idLivro))
                Console.Write("Número inválido, digite de novo: ");

            LivroService livroService = new();
            livroService.AtualizarExemplares(idLivro);
        }

        public IUsuario? Login()
        {
            FuncionarioService funcionarioService = new();
            List<Funcionario>? funcionarios = funcionarioService.LerJSONFuncionarios();

            Console.Write("Código de cadastro: ");
            string codigoCadastro = Console.ReadLine()!;

            Console.Write("Senha: ");
            string senha = LerSenha();

            Funcionario? funcionario = funcionarios.FirstOrDefault(funcionario => funcionario.CodigoCadastro == codigoCadastro && funcionario.Senha == senha);

            if (funcionario == null)
            {
                Console.WriteLine("Código de cadastro ou senha incorreta. Tentar novamente? Digite 'S' para tentar novamente");
                char continuar = Console.ReadKey().KeyChar;
                Console.WriteLine("");

                if (char.ToUpper(continuar) == 'S') { }
                Login();
            }
            else
                return funcionario;

            return null;
        }

        void IUsuario.Logout()
        {
            Console.Clear();
            Console.WriteLine($"Usuário desconectado.");
        }

        public void PesquisarLivro()
        {
            Console.Write("Digite o título do livro ou parte dele: ");
            string? parteTitulo = Console.ReadLine();
            AcervoBiblioteca acervoBiblioteca = new();

            List<Livro> livrosBuscados = acervoBiblioteca.BuscarLivroPorNome(parteTitulo);
            foreach (Livro livro in livrosBuscados)
                livro.ExibirInformacoes();
        }

        public static Funcionario? LocalizarPorCodigo()
        {
            FuncionarioService funcionarioService = new();
            List<Funcionario>? funcionarios = funcionarioService.LerJSONFuncionarios();

            Console.WriteLine("Código de cadastro:");
            string codigoCadastro = Console.ReadLine()!;

            return funcionarios?.FirstOrDefault(funcionario => funcionario.CodigoCadastro == codigoCadastro);
        }

        public static Cargos SelecionarCargo()
        {
            Cargos novoCargo;
            bool deuCerto;

            Console.WriteLine("Cargos: Atendente, Bibliotecario ou Diretor?");
            do
            {
                Console.Write("Escreva o nome do cargo: ");
                deuCerto = Enum.TryParse<Cargos>(Console.ReadLine(), out novoCargo);
            } while (!deuCerto);

            return novoCargo;
        }

        public void Logout()
        {
            Console.Clear();
            Console.WriteLine($"{Cargo} desconectado.");
        }
    }
}
