using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    internal class AcervoPublico: AcervoBiblioteca
    {
        public List<Livro> LivrosPublicos {  get; private set; } = new List<Livro>();
        public override void AdicionarLivro(Livro livro) { }

        public override void RemoverLivro(Livro livro) { }

        public override void BuscarLivroPorTitulo(string titulo) { }

        public override void VerificarDisponibilidade(Livro livro) { }
    }
}
