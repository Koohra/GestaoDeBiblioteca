﻿using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    internal static class AcervoPublico
    {
        public static List<Livro> Livros {  get; private set; }
        internal static void AdicionarLivro(Livro livro) { }

        internal static void RemoverLivro(Livro livro) { }
    }
}
