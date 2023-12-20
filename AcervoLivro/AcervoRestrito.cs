using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    internal static class AcervoRestrito
    {
        public static List<Livro> Livros { get; private set; }
        internal static void AdicionarLivro(Livro livro) { }

        internal static void RemoverLivro(Livro livro) { }
    }
}
