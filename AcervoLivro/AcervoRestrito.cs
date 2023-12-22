using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    internal  class AcervoRestrito: AcervoBiblioteca
    {
        public static List<Livro> LivrosRestritos { get; private set; } = new List<Livro>();
        public override void AdicionarLivro(Livro livro) { }

        public override void RemoverLivro(Livro livro) { }

        public override void BuscarLivroPorTitulo(string titulo) { }

        public override void VerificarDisponibilidade(Livro livro) { }
    }
}
