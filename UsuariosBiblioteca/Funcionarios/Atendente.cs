using ControleDoAcervo.Livros;
using UsuariosBiblioteca.Estudantes;
using UsuariosBiblioteca.Interfaces;
using UsuariosBiblioteca.Professores;

namespace UsuariosBiblioteca.Funcionarios
{
    public class Atendente : Funcionario
    {


        public Atendente(string codigoCadastro, string nome, string email, string senha) : base(codigoCadastro, nome, email, senha)
        {
            Cargo = Cargos.Atendente;
        }

        public void PermitirEmprestimo() {

            Console.WriteLine("Digite o Id do livro:");
            int idLivro;
            while (!int.TryParse(Console.ReadLine(), out idLivro))
            {
                Console.Write("Número inválido, digite de novo: ");
            }
            LivroService livroService = new LivroService();
            Livro livro = livroService.LerLivroPorID(idLivro);

            if (livro != null) livro.EmprestarLivro(livro);
            else Console.WriteLine("Ocorreu um erro, livro não pode ser emprestado");

            //Estudante estudante = Estudante.LocalizarPorMatricula(); //adicionar trycatch
            //estudante.LivroEmprestado == true;
            //estudante.ExibirInformacoes();

        }

        public void ReceberDevolucao()
        {
            Console.WriteLine("Digite o Id do livro:");
            int idLivro;
            while (!int.TryParse(Console.ReadLine(), out idLivro))
            {
                Console.Write("Número inválido, digite de novo: ");
            }
            LivroService livroService = new LivroService();
            Livro livro = livroService.LerLivroPorID(idLivro);

            if (livro != null) livro.DevolverLivro(livro);
            else Console.WriteLine("Ocorreu um erro, livro não pode ser devolvido");
        }

        public void RegistroUsuario() { }//implementar

        public void AtualizarRegistroUsuario()
        {
            Console.WriteLine("ATUALIZAR REGISTRO");
            Console.WriteLine("Selecione tipo de usuário:");
            Console.WriteLine("1- Estudante\n2- Professor\n3-Funcionário");
            int tipousuario;
            while (!int.TryParse(Console.ReadLine(), out tipousuario))
            {
                Console.Write("Digite o número correspondente ao usuário");
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
                defaut:
                    return;
            }


        }

        private void AtualizarEstudante()
        {
            EstudanteService estudanteService = new EstudanteService();
            List<Estudante> estudantes = estudanteService.LerJsonEstudantes() ?? new List<Estudante>();

            Console.WriteLine("EDITAR DADOS: ESTUDANTE");
            Estudante estudante = Estudante.LocalizarPorMatricula(); //adicionar trycatch
            estudante.ExibirInformacoes();

            Console.Write("Nome: ");
            string nomenovo = Console.ReadLine();

            Console.Write("E-mail: ");
            string emailnovo = Console.ReadLine();

            Console.Write("Curso: ");
            string cursonovo = Console.ReadLine();

            estudanteService.AlterarEstudantePorMatricula(estudante.Matricula, nomenovo, emailnovo, cursonovo);

        }

        private void AtualizarProfessor()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> professores = professorService.LerJsonProfessores() ?? new List<Professor>();

            Console.WriteLine("EDITAR DADOS: PROFESSOR");
            Professor professor = Professor.LocalizarPorCodigo(); //adicionar trycatch
            professor.ExibirInformacoes();

            Console.Write("Nome: ");
            string nomenovo = Console.ReadLine();

            Console.Write("E-mail: ");
            string emailnovo = Console.ReadLine();

            Console.Write("Senha: ");
            string senhanova = Console.ReadLine();

            professorService.AlterarProfessorPorCodigo(professor.CodigoCadastro, nomenovo, emailnovo, senhanova);
        }

        private void AtualizarFuncionario()
        {
            FuncionarioService funcionarioService = new FuncionarioService();
            List<Funcionario> listaFuncionarios = funcionarioService.RetornarLista();

            Console.WriteLine("EDITAR DADOS: FUNCIONÁRIO");
            Funcionario funcionario = Funcionario.LocalizarPorCodigo(); //adicionar trycatch
            funcionario.ExibirInformacoes();

            Console.Write("Nome: ");
            string nomenovo = Console.ReadLine();

            Console.Write("E-mail: ");
            string emailnovo = Console.ReadLine();

            Cargos cargonovo = funcionario.MudarCargo();

            Console.Write("Senha: ");
            string senhanova = Console.ReadLine();

            funcionarioService.AlterarFuncionarioPorCodigo(funcionario.CodigoCadastro, nomenovo, emailnovo, cargonovo, senhanova);

        }
    }
}

