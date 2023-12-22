using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    internal interface IBuscarLivro
    {
        // interface que pode estar em todos os acervos
        List<Livro> BuscarLivroPorTitulo(string titulo);
    }
}
