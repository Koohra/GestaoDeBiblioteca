using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public class AcervoBiblioteca
    {
        public virtual void AdicionarLivro(Livro livro) { }

        public virtual void RemoverLivro(Livro livro) { }

        public virtual void BuscarLivroPorTitulo(string titulo) { }

        public virtual void VerificarDisponibilidade(Livro livro) { }
    }
}
