using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public class ForaDeEstoque: AcervoBiblioteca
    {
        public static List<Livro> LivrosForaDeEstoque { 
            get
            {
                LivroService livroService = new LivroService();
                LivrosForaDeEstoque = livroService.LerLivros().Where(livro => livro.Setor == Acervo.ForaDeEstoque).ToList();
                return LivrosForaDeEstoque;
            }
            private set 
            { 

            } 
        }

        public ForaDeEstoque() { }

        public override List<Livro> BuscarLivroPorTitulo(string titulo) { }

        public override void VerificarDisponibilidade(Livro livro) { }
    }
}
