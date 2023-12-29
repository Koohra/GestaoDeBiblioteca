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
                if (estado == EstadoExemplar.Conservado && quantidade > 2)
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
            // verificar acervo, se usuario for estudante ou professor a reserva nao pode ser aceita
            // se for possivel criar reserva 
            // ordenar a lista de reservas primeiro por cargo do usuário, depois por data
            //Reservas.OrderBy(reserva => reserva.CargoUsuario).ThenBy()
            // retorna a reserva adicionada
        }

        public Reserva RemoverReserva()
        {
            // remover o primeiro da lista de reservas, porque ela já está ordenada
            // retorna a reserva removida
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
