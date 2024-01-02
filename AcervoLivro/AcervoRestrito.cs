using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    internal  class AcervoRestrito: AcervoBiblioteca
    {
        public static List<Livro> LivrosRestritos { get
            {
                LivroService livroService = new LivroService();
                LivrosRestritos = livroService.LerLivros().Where(livro => livro.Setor == Acervo.Restrito).ToList();
                return LivrosRestritos;
            }
            private set { }
        }

        public AcervoRestrito() { }

        public override List<Livro> BuscarLivroPorTitulo(string titulo) { }

        public override void VerificarDisponibilidade(Livro livro) { }
    }
}
