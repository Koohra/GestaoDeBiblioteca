using ControleDoAcervo.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosBiblioteca
{
    internal class Estudante   //Herda de usuário ou coloca nome e email?
    {
        public int Matricula { get; private set; }
        //public string Nome { get; set; }
        //public string Email { get; set; }
        public string Curso { get; set; }
        public int AnoDeIngresso { get; set; }
        public bool LivroEmprestado { get; set; }
    }
}