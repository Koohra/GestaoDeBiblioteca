using ControleDoAcervo;
using ControleDoAcervo.Livros;
using System.Globalization;
using UsuariosBiblioteca.Funcionarios;
using System.Linq;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Professores
{
    public class Professor : IUsuario, ISenha
    {
        public string? CodigoCadastro { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? ProximaAlteracaoDeSenha { get; set; }
        public int QuantidadeDeLivrosEmprestados { get; set; }

        public Professor() { }

        public IUsuario Login()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> professores = professorService.LerJsonProfessores() ?? new List<Professor>();

            while (true)
            {
                Console.WriteLine("Digite seu código de cadastro:");
                string codigoCadastro = Console.ReadLine();

                Console.WriteLine("Digite sua senha:");
                string senha = Console.ReadLine();

                Professor professor = professores.FirstOrDefault(predicate: p => p.CodigoCadastro == codigoCadastro);

                if (professor != null)
                {
                    if (professor.Senha == senha)
                    {
                        if (SenhaExpirada(professor))
                        {
                            Console.WriteLine("Por favor, altere sua senha.");
                            Console.WriteLine("Digite a nova senha:");

                            string novaSenha = Console.ReadLine();
                            professorService.AlterarSenha(codigoCadastro, novaSenha);
                        }

                        Console.WriteLine($"Login bem-sucedido! Bem-vindo, {professor.Nome}.");
                        return professor;
                    }
                    else
                    {
                        Console.WriteLine("Senha incorreta.");
                    }
                }
                else
                {
                    Console.WriteLine("Código de cadastro incorreto.");
                }

                Console.WriteLine("O que deseja fazer?");
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

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Código de Cadastro: {CodigoCadastro}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Email: {Email} ");
            Console.WriteLine();
        }
        public void Logout()
        {
            Console.Clear();
            Console.WriteLine($"Usuário desconectado.");
        }

        public void PesquisarLivro()
        {
            AcervoPublico acervoPublico = new AcervoPublico();
            AcervoRestrito acervoRestrito = new AcervoRestrito();
            List<Livro> livrosPublicosBuscados = acervoPublico.BuscarLivroPorParteDoNome();
            List<Livro> livrosRestritosBuscados = acervoRestrito.BuscarLivroPorParteDoNome();

            List<Livro> livrosBuscados = livrosPublicosBuscados.Concat(livrosRestritosBuscados).ToList();
            
            foreach(Livro livro in livrosBuscados)
            {
                livro.ExibirInformacoes();
            }
        }

        public void AlterarSenhaMensal() { }//já tinha um método parecido na ProfessorService

        public void ValidarSenha(string senha) // Faltam informações
        {
            throw new NotImplementedException();
        }
        private bool SenhaExpirada(Professor professor)
        {
            DateTime proximaAlteracao = DateTime.ParseExact(professor.ProximaAlteracaoDeSenha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return DateTime.Now >= proximaAlteracao;
        }

        public static Professor LocalizarPorCodigo()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> professores = professorService.LerJsonProfessores() ?? new List<Professor>();

            Console.WriteLine("Código de cadastro:");
            string codigoCadastro = Console.ReadLine()!;

            foreach (Professor professor in professores)
            {
                if (professor.CodigoCadastro == codigoCadastro)
                {
                    return professor;
                }
            }
            return null;
        }


    }
}
