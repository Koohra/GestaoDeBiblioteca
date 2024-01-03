using ControleDoAcervo.Reservas;
using System.Text;

namespace ControleDoAcervo.Livros
{
    public class Livro
    {
        private static int contadorId = 0;
        public int Id { get; private set; }
        public string Titulo { get; internal set; }
        public string Autor { get; internal set; }
        public int AnoPublicacao { get; internal set; }
        public Dictionary<EstadoExemplar, int> Exemplares { get; set; }
        public Acervo Setor { get; internal set; }
        public List<Reserva> Reservas { get; internal set; }

        public Livro(string titulo, string autor, int anoPublicacao, Dictionary<EstadoExemplar, int> exemplares)
        {
            Id = contadorId++;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Exemplares = exemplares;
            VerificarSetor(exemplares);
            Reservas = new List<Reserva>();
        }

        private void VerificarSetor(Dictionary<EstadoExemplar, int> exemplares)
        {
            int quantidadeLivrosDisponiveis = exemplares.GetValueOrDefault(EstadoExemplar.Conservado, 0)
                + exemplares.GetValueOrDefault(EstadoExemplar.MalConservado, 0)
                + exemplares.GetValueOrDefault(EstadoExemplar.Emprestado, 0);

            //int quantidadeLivrosDisponiveis = exemplares[EstadoExemplar.Conservado] + exemplares[EstadoExemplar.MalConservado];  //exemplares.Values.Sum()
            foreach (var (estado, quantidade) in exemplares)
            {
                if (estado == EstadoExemplar.Conservado && quantidade >= 2)
                {
                    Setor = Acervo.Publico;
                    break;
                }
                else if (estado == EstadoExemplar.Conservado && quantidade == 1 ||
                         estado == EstadoExemplar.MalConservado && quantidade == quantidadeLivrosDisponiveis)
                {
                    Setor = Acervo.Restrito;
                    break;
                }
                else if (estado == EstadoExemplar.Emprestado && quantidade == quantidadeLivrosDisponiveis
                        || quantidadeLivrosDisponiveis == 0 && ((estado == EstadoExemplar.TotalmenteDanificado && quantidade >=1)
                        || (estado == EstadoExemplar.Perdido && quantidade >= 1)))
                {
                    Setor = Acervo.ForaDeEstoque;
                    break;
                }
            }
        }

        public static Dictionary<EstadoExemplar, int> ReceberEstadoExemplar()
        {
            Dictionary<EstadoExemplar, int> estadosLivro = new Dictionary<EstadoExemplar, int>();
            foreach (string estadoString in Enum.GetNames(typeof(EstadoExemplar)))
            {
                EstadoExemplar estado;
                if (Enum.TryParse(estadoString, out estado))
                {
                    bool esperaQuantidade = true;

                    string estadoNome = estado.ToString();
                    StringBuilder resultado = new StringBuilder();
                    foreach (char caracter in estadoNome)
                    {
                        if (char.IsUpper(caracter) && resultado.Length > 0)
                        {
                            resultado.Append(' ');
                        }
                        resultado.Append(char.ToLower(caracter));
                        estadoNome = resultado.ToString();

                    }

                    do
                    {
                        Console.WriteLine($"Digite a quantidade de livros em estado {estadoNome}");
                        if (int.TryParse(Console.ReadLine(), out int quantidade))
                        {
                            estadosLivro.Add(estado, quantidade);
                            esperaQuantidade = false;
                        }
                        else
                        {
                            Console.WriteLine("Esta não é uma quantidade válida.");
                        }
                    } while (esperaQuantidade);
                }
            }
            return estadosLivro;
        }


        public void AtualizarExemplares() 
        {
            Exemplares = ReceberEstadoExemplar();
            VerificarSetor(Exemplares);
        }

        public void AdicionarExemplar(EstadoExemplar estado, int quantidade)
        {
            if (Exemplares.ContainsKey(estado))
                Exemplares[estado] += quantidade;
            else
            {
                bool deuCerto = Exemplares.TryAdd(estado, quantidade);
                if (!deuCerto)
                    throw new ArgumentException("Não foi possível adicionar exemplar.");
            }

            VerificarSetor(Exemplares);
        }

        public void RemoverExemplar(EstadoExemplar estado, int quantidade)
        {
            if (Exemplares.ContainsKey(estado) && Exemplares[estado] >= quantidade)
                Exemplares[estado] -= quantidade;
            else
                throw new ArgumentException("Não existe a quantidade de exemplares neste estado deste livro.");

            VerificarSetor(Exemplares);
        }

        public Reserva AdicionarReserva(string matricula)
        {
            CargoUsuario cargoUsuario;
            DateTime dataReserva;
            bool deuCerto;
            
            do
            {
                Console.WriteLine("Entre com a data da reserva:");
                deuCerto = DateTime.TryParse(Console.ReadLine(), out dataReserva);
            } while (!deuCerto);

            if (matricula.Any(digito => digito == 'p'))
                cargoUsuario = CargoUsuario.Professor;
            else
                cargoUsuario = CargoUsuario.Estudante;

            if (this.Setor == Acervo.ForaDeEstoque)
                throw new AccessViolationException("Não é possível reservar um livro fora de estoque.");
            else if (this.Setor == Acervo.Restrito && cargoUsuario == CargoUsuario.Estudante)
                throw new AccessViolationException("Estudante não tem acesso ao acervo restrito.");

            Reserva novaReserva = new Reserva(matricula, cargoUsuario, dataReserva);
            Reservas.Add(novaReserva);

            Reservas = Reservas
                    .OrderByDescending(reserva => reserva.CargoUsuario)
                    .ThenBy(reserva => reserva.DataReserva)
                    .ToList();

            
            return novaReserva;
        }

        public Reserva RemoverReserva()
        {
            if (Reservas.Count > 0)
            {
                Reserva reservaRemovida = Reservas[0];
                Reservas.RemoveAt(0);
                return reservaRemovida;
            }
            else
            {
                throw new InvalidOperationException("Não á reserva para remover.");
            }
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Ano de publicação: {AnoPublicacao}");
            Console.WriteLine($"Setor: {Setor}");
            Console.WriteLine();
        }
    }
}
