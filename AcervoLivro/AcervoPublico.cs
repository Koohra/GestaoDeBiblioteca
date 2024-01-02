using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    internal class AcervoPublico: AcervoBiblioteca
    {
        public List<Livro> LivrosPublicos {
            get
            {
                LivroService livroService = new LivroService();
                LivrosPublicos = livroService.LerLivros().Where(livro => livro.Setor == Acervo.Publico).ToList();
                return LivrosPublicos;
            }
            private set { }
        }

        public AcervoPublico() 
        {
            LivrosPublicos = new List<Livro>();
        }

        public override List<Livro> BuscarLivroPorTitulo(string titulo) { }

        public override void VerificarDisponibilidade(Livro livro) { }
    }
}
