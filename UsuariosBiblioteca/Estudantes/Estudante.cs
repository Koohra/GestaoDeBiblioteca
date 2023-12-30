using ControleDoAcervo.Livros;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Estudantes
{
    public class Estudante : IUsuario
    {
        public int Matricula { get; private set; }
        public string? Curso { get; set; }
        public int AnoDeIngresso { get; set; }
        public bool LivroEmprestado { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public object InterfaceEstudante { get; private set; }

        public Estudante() { }

        public IUsuario Login()
        {
            EstudanteService estudanteService = new EstudanteService();
            List<Estudante> estudantes = estudanteService.LerJsonEstudantes() ?? new List<Estudante>();

            while (true)
            {
                Console.WriteLine("Digite sua matrícula:");

                if (int.TryParse(Console.ReadLine(), out int matricula))
                {
                    Estudante estudante = estudantes.FirstOrDefault(e => e.Matricula == matricula);

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
        }
        public void Logout()
        {
            Console.WriteLine($"Usuário desconectado.");
        }
        public void PesquisarLivro(string livroBuscado)
        {
            LivroService livroService = new LivroService();
            List<Livro> livros = livroService.LerLivros() ?? new List<Livro>();

            foreach (var livro in livros)
            {
                if (livro.Titulo.Equals(livroBuscado, StringComparison.OrdinalIgnoreCase) && livro.Setor == Acervo.Publico)
                {
                    Console.WriteLine($"Título: {livro.Titulo}");
                    Console.WriteLine($"Autor: {livro.Autor}");
                    Console.WriteLine($"Ano de Publicação: {livro.AnoPublicacao}");
                    Console.WriteLine($"Setor: {livro.Setor}");

                    var disponibilidade = VerificarDisponibilidade(livro);
                    Console.WriteLine($"Exemplares Disponíveis: {disponibilidade}");

                    var numeroReservas = livro.Reservas.Count;
                    Console.WriteLine($"Número de Reservas: {numeroReservas}");

                    return;
                }
            }

            Console.WriteLine($"Livro '{livroBuscado}' não encontrado no acervo público.");
        }

        private int VerificarDisponibilidade(Livro livro)
        {
            int exemplaresDisponiveis = livro.Exemplares
                .Where(e => e.Key == EstadoExemplar.Conservado && e.Value > 0)
                .Sum(e => e.Value);

            return exemplaresDisponiveis;
        }

    }
}