using ControleDoAcervo.Livros;
using UsuariosBiblioteca.Estudantes;
using UsuariosBiblioteca.Professores;

namespace UsuariosBiblioteca.Funcionarios
{
    public class Atendente : Funcionario
    {
        public Atendente(string codigoCadastro, string nome, string email, string senha) : base(codigoCadastro, nome, email, senha)
        {
            Cargo = Cargos.Atendente;
        }

        public static void PermitirEmprestimo() {

            Console.Write("Digite o ID do livro: ");
            int idLivro;

            while (!int.TryParse(Console.ReadLine(), out idLivro))
            {
                Console.Write("Número inválido, digite de novo: ");
            }

            LivroService livroService = new();
            Livro? livro = livroService.LerLivroPorID(idLivro);

            if (livro != null) 
                Livro.EmprestarLivro(livro);
            else 
                Console.WriteLine("Livro não pode ser emprestado.");
        }

        public static void ReceberDevolucao()
        {
            Console.Write("Digite o ID do livro: ");
            int idLivro;

            while (!int.TryParse(Console.ReadLine(), out idLivro))
            {
                Console.Write("Número inválido, digite de novo: ");
            }

            LivroService livroService = new();
            Livro? livro = livroService.LerLivroPorID(idLivro);

            if (livro != null) 
                Livro.DevolverLivro(livro);
            else 
                Console.WriteLine("Ocorreu um erro: Livro não pode ser devolvido.");
        }

        public void AtualizarRegistroUsuario()
        {
            Console.WriteLine("ATUALIZAR REGISTRO");
            Console.WriteLine("Selecione tipo de usuário:");
            Console.WriteLine("1- Estudante\n2- Professor\n3-Funcionário");

            int tipousuario;

            while (!int.TryParse(Console.ReadLine(), out tipousuario) || tipousuario < 1 || tipousuario > 3)
            {
                Console.Write("Digite o número correspondente ao usuário: ");
            }

            switch (tipousuario)
            {
                case 1:
                    AtualizarEstudante();
                    return;
                case 2:
                    AtualizarProfessor();
                    return;
                case 3:
                    AtualizarFuncionario();
                    return;
                default:
                    return;
            }
        }

        private static void AtualizarEstudante()
        {
            EstudanteService estudanteService = new EstudanteService();
            List<Estudante> estudantes = estudanteService.LerJSONEstudantes() ?? [];

            Console.WriteLine("EDITAR DADOS: ESTUDANTE");
            Estudante? estudante = Estudante.LocalizarPorMatricula();
            estudante!.ExibirInformacoes();

            Console.Write("Nome: ");
            string nomenovo = Console.ReadLine()!;

            Console.Write("E-mail: ");
            string emailnovo = Console.ReadLine()!;

            Console.Write("Curso: ");
            string cursonovo = Console.ReadLine()!;

            estudanteService.AlterarEstudantePorMatricula(estudante.Matricula, nomenovo, emailnovo, cursonovo);
        }

        private static void AtualizarProfessor()
        {
            ProfessorService professorService = new();
            List<Professor> professores = professorService.LerJSONProfessores() ?? [];

            Console.WriteLine("EDITAR DADOS: PROFESSOR");
            Professor professor = Professor.LocalizarPorCodigo();
            professor.ExibirInformacoes();

            Console.Write("Nome: ");
            string nomenovo = Console.ReadLine()!;

            Console.Write("E-mail: ");
            string emailnovo = Console.ReadLine()!;

            Console.Write("Senha: ");
            string senhanova = Console.ReadLine()!;

            professorService.AlterarProfessorPorCodigo(professor.CodigoCadastro!, nomenovo, emailnovo, senhanova);
        }

        private static void AtualizarFuncionario()
        {
            FuncionarioService funcionarioService = new();

            Console.WriteLine("EDITAR DADOS: FUNCIONÁRIO");
            Funcionario funcionario = LocalizarPorCodigo();
            funcionario.ExibirInformacoes();

            Console.Write("Nome: ");
            string nomenovo = Console.ReadLine()!;

            Console.Write("E-mail: ");
            string emailnovo = Console.ReadLine()!;

            Cargos cargonovo = SelecionarCargo();

            Console.Write("Senha: ");
            string senhanova = Console.ReadLine()!;

            funcionarioService.AlterarFuncionarioPorCodigo(funcionario.CodigoCadastro!, nomenovo, emailnovo, cargonovo, senhanova);

        }
    }
}

