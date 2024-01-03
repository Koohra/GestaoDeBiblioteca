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

        public void RegistroUsuario() { }// provavelmente tem que receber algo
        public void PermitirEmprestimo(Livro livro, Estudante aluno) { }
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


        } // provavelmente tem que receber algo

        private void AtualizarEstudante()
        {
            EstudanteService estudanteService = new EstudanteService();
            List<Estudante> estudantes = estudanteService.LerJsonEstudantes() ?? new List<Estudante>();

            Estudante estudante = Estudante.LocalizarPorMatricula(); //adicionar trycatch

            estudante.ExibirInformacoes();

            Console.WriteLine("");
            Console.WriteLine("O que deseja alterar?");
            Console.WriteLine("1- Nome\n2- E-mail\n3- Curso");
            int modificar;
            while (!int.TryParse(Console.ReadLine(), out modificar))
            {
                Console.Write("Digite o número correspondente;");
            }

            switch (modificar)
            {
                case 1:
                    Console.Write("Nome: ");
                    estudante.Nome = Console.ReadLine();
                    return;
                case 2:
                    Console.Write("E-mail: ");
                    estudante.Email = Console.ReadLine();
                    return;
                case 3:
                    Console.Write("Curso: ");
                    estudante.Curso = Console.ReadLine();
                    return;
                defaut:
                    return;
            }

        }

        private void AtualizarProfessor()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> professores = professorService.LerJsonProfessores() ?? new List<Professor>();

            Professor professor = Professor.LocalizarPorCodigo(); //adicionar trycatch

            professor.ExibirInformacoes();

            Console.WriteLine("");
            Console.WriteLine("O que deseja alterar?");
            Console.WriteLine("1- Nome\n2- E-mail\n3- ");
            int modificar;
            while (!int.TryParse(Console.ReadLine(), out modificar))
            {
                Console.Write("Digite o número correspondente;");
            }

            switch (modificar)
            {
                case 1:
                    Console.Write("Nome: ");
                    professor.Nome = Console.ReadLine();
                    Console.Write("Cadastro Atualizado:");
                    professor.ExibirInformacoes();
                    return;
                case 2:
                    Console.Write("E-mail: ");
                    professor.Email = Console.ReadLine();
                    Console.Write("Cadastro Atualizado:");
                    professor.ExibirInformacoes();
                    return;
                case 3:

                    return;
                defaut:
                    return;
            }

            
        }

        private void AtualizarFuncionario()
        {
            FuncionarioService funcionarioService = new FuncionarioService();
            List<Funcionario> listaFuncionarios = funcionarioService.RetornarLista();

            Funcionario funcionario = Funcionario.LocalizarPorCodigo(); //adicionar trycatch

            funcionario.ExibirInformacoes();

            Console.WriteLine("");
            Console.WriteLine("O que deseja alterar?");
            Console.WriteLine("1- Nome\n2- E-mail\n3- Cargo");
            int modificar;
            while (!int.TryParse(Console.ReadLine(), out modificar))
            {
                Console.Write("Digite o número correspondente;");
            }

            switch (modificar)
            {
                case 1:
                    Console.Write("Nome: ");
                    funcionario.Nome = Console.ReadLine();
                    funcionario.ExibirInformacoes();
                    return;
                case 2:
                    Console.Write("E-mail: ");
                    funcionario.Email = Console.ReadLine();
                    funcionario.ExibirInformacoes();
                    return;
                case 3:
                    
                    return;
                defaut:
                    return;
            }

        }
    }
}

