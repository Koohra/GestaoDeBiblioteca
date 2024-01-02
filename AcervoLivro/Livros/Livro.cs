using ControleDoAcervo.Reservas;

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
            int quantidadeTotalLivros = exemplares.Values.Sum();
            foreach (var (estado, quantidade) in exemplares)
            {
                if (estado == EstadoExemplar.Conservado && quantidade >= 2)
                {
                    Setor = Acervo.Publico;
                    break;
                }
                else if (estado == EstadoExemplar.Conservado && quantidade == 1 ||
                         estado == EstadoExemplar.MalConservado && quantidade == quantidadeTotalLivros)
                {
                    Setor = Acervo.Restrito;
                    break;
                }
                else if (estado == EstadoExemplar.Conservado && quantidade == 0)
                {
                    Setor = Acervo.ForaDeEstoque;
                    break;
                }
            }
        }

        public void AtualizarExemplares(Dictionary<EstadoExemplar, int> exemplares) 
        {
            Exemplares = exemplares;
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

        public Reserva AdicionarReserva(string matricula, DateTime? dataReserva)
        {
            CargoUsuario cargoUsuario;

            if (matricula.Any(digito => digito == 'p'))
                cargoUsuario = CargoUsuario.Professor;
            else
                cargoUsuario = CargoUsuario.Estudante;

            if (this.Setor == Acervo.ForaDeEstoque)
            {
                throw new AccessViolationException("Não é possível reservar um livro fora de estoque.");
            } 
            else if (this.Setor == Acervo.Restrito && cargoUsuario == CargoUsuario.Estudante)
            {
                throw new AccessViolationException("Estudante não tem acesso ao acervo restrito.");
            }

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
        }
    }
}
