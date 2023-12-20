using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDoAcervo.Livros;

namespace ControleDoAcervo
{
    internal class AcervoBiblioteca
    {
        public List<Livro> Livros {  get; private set; }

        public void AdicionarLivro(Livro livro)
        {
            Livros.Add(livro);
            if (livro.SetorLocal == Acervo.Publico)
                AcervoPublico.AdicionarLivro(livro);
            else if (livro.SetorLocal == Acervo.Restrito)
                AcervoRestrito.AdicionarLivro(livro);
            else if (livro.SetorLocal == Acervo.ForaDeEstoque)
                ForaDeEstoque.AdicionarLivro(livro);
        }

        public void RemoverLivro(Livro livro)
        {
            Livros.Remove(livro);
            if (livro.SetorLocal == Acervo.Publico)
                AcervoPublico.RemoverLivro(livro);
            else if (livro.SetorLocal == Acervo.Restrito)
                AcervoRestrito.RemoverLivro(livro);
            else if (livro.SetorLocal == Acervo.ForaDeEstoque)
                ForaDeEstoque.RemoverLivro(livro);
        }

        public List<Livro> BuscarLivroPorTitulo (string titulo)
        {
            return Livros.Where(livro => livro.Titulo == titulo).ToList();
        }

        public void VerificarDisponibilidade(Livro livro)
        {
            // não sei como implementar ainda
        }
    }
}
