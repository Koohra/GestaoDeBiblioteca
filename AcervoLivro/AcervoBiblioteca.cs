using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public class AcervoBiblioteca
    {
        public List<Livro> Livros { 
            get
            {
                LivroService livroService = new LivroService();
                Livros = livroService.LerLivros();
                return Livros;
            } 
            private set { } }

        public AcervoBiblioteca() { }

        public void AdicionarLivro(Livro livro) { }

        public void RemoverLivro(Livro livro) { }

        public virtual List<Livro> BuscarLivroPorTitulo(string titulo) { }

        public virtual void VerificarDisponibilidade(Livro livro) { }
    }
}
