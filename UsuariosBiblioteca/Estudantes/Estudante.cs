﻿using ControleDoAcervo;
using ControleDoAcervo.Livros;
using System.Globalization;
using UsuariosBiblioteca.Funcionarios;
using UsuariosBiblioteca.Interfaces;
using UsuariosBiblioteca.Professores;

namespace UsuariosBiblioteca.Estudantes
{
    public class Estudante : IUsuario
    {
        public string Matricula { get; set; }
        public string? Curso { get; set; }
        public int AnoDeIngresso { get; set; }
        public bool LivroEmprestado { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public object InterfaceEstudante { get; private set; }

        public Estudante() { }

        public IUsuario? Login()
        {
            EstudanteService estudanteService = new EstudanteService();
            List<Estudante> estudantes = estudanteService.LerJsonEstudantes(); //?? new List<Estudante>();


            while (true)
            {
                Console.WriteLine("Digite sua matrícula:");

                //if (int.TryParse(Console.ReadLine(), out int matricula))
                string matricula = Console.ReadLine();
                Estudante? estudante = estudantes.FirstOrDefault(e => e.Matricula == matricula);

                if (estudante != null)
                {
                    Console.WriteLine($"Login bem-sucedido! Bem-vindo, {estudante.Nome}.");
                    return estudante;
                }

                Console.WriteLine("Matrícula inválida. O que deseja fazer?");
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
            Console.WriteLine($"Número de matrícula: {Matricula}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Email: {Email} ");
            Console.WriteLine($"Curso: {Curso}");
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
            List<Livro> livrosPublicosBuscados = acervoPublico.BuscarLivroPorParteDoNome();

            foreach (Livro livro in livrosPublicosBuscados)
            {
                livro.ExibirInformacoes();
            }
        }

        private int VerificarDisponibilidade(Livro livro)
        {
            int exemplaresDisponiveis = livro.Exemplares
                .Where(e => e.Key == EstadoExemplar.Conservado && e.Value > 0)
                .Sum(e => e.Value);

            return exemplaresDisponiveis;
        }

        public static Estudante LocalizarPorMatricula()
        {
            EstudanteService estudanteService = new EstudanteService();
            List<Estudante> estudantes = estudanteService.LerJsonEstudantes() ?? new List<Estudante>();

            //int matricula;
            Console.WriteLine("Digite o número da matrícula:");
            //while (!int.TryParse(Console.ReadLine(), out matricula))
            //{
            //    Console.Write("Formato inválido, digite de novo: ");
            //}
            string matricula = Console.ReadLine();
            //Estudante estudante = estudantes.FirstOrDefault(e => e.Matricula == matricula);

            //if (estudante != null)
            //{
            //    return estudante;
            //}

            foreach (Estudante estudante in estudantes)
            {
                if (estudante.Matricula == matricula)
                {
                    return estudante;
                }
            }

            return null;
        }

    }
}
