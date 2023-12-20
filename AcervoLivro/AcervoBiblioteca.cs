using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    public static class AcervoBiblioteca
    {
        public static List<Livro> Livros {  get; private set; } = new();

        public static void AdicionarLivro(Livro livro)
        {
            Livros.Add(livro);
            if (livro.SetorLocal == Acervo.Publico)
                AcervoPublico.AdicionarLivro(livro);
            else if (livro.SetorLocal == Acervo.Restrito)
                AcervoRestrito.AdicionarLivro(livro);
            else if (livro.SetorLocal == Acervo.ForaDeEstoque)
                ForaDeEstoque.AdicionarLivro(livro);
        }

        public static void RemoverLivro(Livro livro)
        {
            Livros.Remove(livro);
            if (livro.SetorLocal == Acervo.Publico)
                AcervoPublico.RemoverLivro(livro);
            else if (livro.SetorLocal == Acervo.Restrito)
                AcervoRestrito.RemoverLivro(livro);
            else if (livro.SetorLocal == Acervo.ForaDeEstoque)
                ForaDeEstoque.RemoverLivro(livro);
        }

        public static List<Livro> BuscarLivroPorTitulo (string titulo)
        {
            return Livros.Where(livro => livro.Titulo == titulo).ToList();
        }

        public static void VerificarDisponibilidade(Livro livro)
        {
            // não sei como implementar ainda
        }
    }
}
