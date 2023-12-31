﻿using ControleDoAcervo;
using ControleDoAcervo.Livros;
using System.Globalization;
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

        private static void CodificarSenha(string senha)
        {
            for(int i = 0; i < senha.Length; i++)
            {
                Console.Write("*");
            }
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

        public IUsuario Login()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> professores = professorService.LerJSONProfessores() ?? new List<Professor>();

            while (true)
            {
                Console.WriteLine("Digite seu código de cadastro:");
                string codigoCadastro = Console.ReadLine();

                Console.WriteLine("Digite sua senha:");
                string senha = LerSenha();

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
            Console.WriteLine("Digite o título do livro ou parte dele:");
            string? parteTitulo = Console.ReadLine();

            AcervoPublico acervoPublico = new AcervoPublico();
            AcervoRestrito acervoRestrito = new AcervoRestrito();
            List<Livro> livrosPublicosBuscados = acervoPublico.BuscarLivroPorNome(parteTitulo);
            List<Livro> livrosRestritosBuscados = acervoRestrito.BuscarLivroPorNome(parteTitulo);

            List<Livro> livrosBuscados = livrosPublicosBuscados.Concat(livrosRestritosBuscados).DistinctBy(livro => livro.Titulo).ToList();

            foreach (Livro livro in livrosBuscados)
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
            List<Professor> professores = professorService.LerJSONProfessores() ?? new List<Professor>();

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
